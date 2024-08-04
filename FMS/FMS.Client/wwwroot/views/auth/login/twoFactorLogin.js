var app = angular.module('templating_app');
app.service("TwoFactorLoginSvc", function ($http, apiUrl) {
    this.signInWithOTP = function (user) {
        var response = $http({
            method: "post",
            url: apiUrl + "SignIn/SignInWithOTP",
            data: JSON.stringify(user),
            headers: {
                'Content-Type': 'application/json'
                //'Authorization': 'Bearer ' + token
            }
        })
        return response;
    }
})
app.controller('TwoFactorLoginCtrl', function ($scope, $routeParams, $location, LocalStorageService, TwoFactorLoginSvc) {
    $scope.loginWithOTP = function () {
        var email = $routeParams.email;
        var otp = $scope.password;
        var user = {
            Email: email,
            OTP: otp
        }
        var login_user = TwoFactorLoginSvc.signInWithOTP(user);
        login_user.then(function (response, status, headers, config) {
            let obj = response.data;
            if (response.data.responseCode == 200) {
                LocalStorageService.setToken(obj.data.jwtToken);
                LocalStorageService.setUserMail(user.Email);
                $location.path('/dashboard');
            }
        })
    };
})