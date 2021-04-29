import 'dart:io';
import 'package:http/http.dart';
import 'package:http/http.dart' as http;

class Api {
  static String accessToken;
  static const String _baseUrl = "https://10.0.2.2/api";
  static Map<String, String> headers = {
    'Content-type': 'application/json',
    'Accept': 'application/json',
    HttpHeaders.authorizationHeader: "Bearer $accessToken",
  };

  static Future<Response> getUserDetails() async {
    final url = '$_baseUrl/identity/my-profile';
    final response = await http.get(
      url,
      headers: {HttpHeaders.authorizationHeader: "Bearer $accessToken"},
    );

    return response;
  }

  // Example API method call
  static Future<Response> getUsers() async {
    final response =
        await http.get("$_baseUrl/identity/users", headers: headers);

    if (response.statusCode == 200) {
      // Logic here
    }
    return response;
  }
}
