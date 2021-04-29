import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_appauth/flutter_appauth.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:flutter_app/ui/view/auth/widgets/login.dart';
import 'package:flutter_app/core/models/api.dart';

final FlutterAppAuth appAuth = FlutterAppAuth();
final FlutterSecureStorage secureStorage = const FlutterSecureStorage();

// ConsumeAbpFromFlutterApp Api details
const DOMAIN =
    '10.0.2.2:44381'; // 10.0.2.2 used here due to localhost cannot be resolved.
const CLIENT_ID = 'ConsumeAbpFromFlutterApp_FlutterApp';
const CLIENT_SECRET = "1q2w3e*";

const REDIRECT_URI = 'com.example.app://callback';
const ISSUER = 'https://$DOMAIN';

class Auth extends StatefulWidget {
  static const route = "/newauth";

  @override
  _AuthState createState() => _AuthState();
}

class _AuthState extends State<Auth> {
  bool isBusy = false;
  bool isLoggedIn = false;
  String errorMessage;
  String name;
  String picture;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: isBusy
            ? CircularProgressIndicator()
            : Login(loginAction, errorMessage),
      ),
    );
  }

  Map<String, dynamic> parseIdToken(String idToken) {
    final parts = idToken.split(r'.');
    assert(parts.length == 3);

    return jsonDecode(
        utf8.decode(base64Url.decode(base64Url.normalize(parts[1]))));
  }

  getUserDetails() async {
    var profileDetails = {};
    Api.getUserDetails().then(
      (response) {
        if (response.statusCode == 200) {
          profileDetails = jsonDecode(response.body);
        } else {
          throw Exception('Failed to get user details');
        }
      },
    );
    return profileDetails;
  }

  Future<void> loginAction() async {
    setState(() {
      isBusy = true;
      errorMessage = '';
    });

    try {
      final AuthorizationTokenResponse result =
          await appAuth.authorizeAndExchangeCode(
        AuthorizationTokenRequest(CLIENT_ID, REDIRECT_URI,
            clientSecret: CLIENT_SECRET,
            issuer: 'https://$DOMAIN',
            scopes: ["email", "openid", "profile", "role", "phone", "address"],
            promptValues: ['login']),
      );

      // Set access token for application
      Api.accessToken = result.accessToken;

      final idToken = parseIdToken(result.idToken);
      final profile = await getUserDetails();
      await secureStorage.write(
          key: 'refresh_token', value: result.refreshToken);

      // This setstate is most likely not needed
      setState(() {
        isBusy = false;
        isLoggedIn = true;
        name = idToken['name'];
        picture = profile['picture'];
      });
    } catch (e, s) {
      print('login error: $e - stack: $s');
      setState(() {
        isBusy = false;
        isLoggedIn = false;
        errorMessage = e.toString();
      });
    }
  }

  @override
  void initState() {
    initAction();
    super.initState();
  }

  void initAction() async {
    final storedRefreshToken = await secureStorage.read(key: 'refresh_token');
    if (storedRefreshToken == null) return;

    setState(() {
      isBusy = true;
    });

    try {
      final response = await appAuth.token(TokenRequest(
        CLIENT_ID,
        REDIRECT_URI,
        issuer: ISSUER,
        refreshToken: storedRefreshToken,
      ));

      final idToken = parseIdToken(response.idToken);
      final profile = await getUserDetails();

      secureStorage.write(key: 'refresh_token', value: response.refreshToken);

      setState(() {
        isBusy = false;
        isLoggedIn = true;
        name = idToken['name'];
        picture = profile['picture'];
      });
    } catch (e, s) {
      print('error on refresh token: $e - stack: $s');
      setState(() {
        isBusy = false;
        isLoggedIn = false;
      });
    }
  }
}
