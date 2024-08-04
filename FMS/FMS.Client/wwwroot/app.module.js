angular.module("templating_app", ['ngRoute'])
    .constant('apiUrl', 'https://localhost:7118/')
    .config(function ($routeProvider, $locationProvider, $httpProvider) {
        window.history && window.history.pushState && $locationProvider.html5Mode({
            enabled: true,
            requireBase: true
        }).hashPrefix("!");

        $routeProvider
            .when("/", {
                redirectTo: "/login",
            })
            .when("/login", {
                templateUrl: "./views/auth/login/login.html",
                controller: "LoginCtrl"
            })
            .when("/twoFactorLogin/:email", {
                templateUrl: "./views/auth/login/twoFactorLogin.html",
                controller: "Login2faCtrl"
            })
            .when("/forgotPassword", {
                templateUrl: "./views/auth/login/forgotPassword.html",
                controller: "ForgotpasswordCtrl"
            })
            .when("/resetPassword", {
                templateUrl: "./views/auth/login/resetPassword.html",
                controller: "ResetpasswordCtrl"
            })
            .when("/signUp", {
                templateUrl: "./views/auth/signup/signup.html",
                controller: "SignUpCtrl"
            })
            .when("/sendConformationMail", {
                templateUrl: "./views/auth/signup/sendconfirmmail.html",
                controller: "SendConfirmMailCtrl"
            })
            .when("/verifyConformationMail", {
                templateUrl: "./views/auth/signup/verifyconfirmmail.html",
                controller: "VerifyConfirmMailCtrl"
            })
            .when("/resendConformationMail", {
                templateUrl: "./views/auth/signup/resendconfirmmail.html",
                controller: "ResendConfirmMailCtrl"
            })
            .when('/userBranch', {
                templateUrl: './views/dashboard/userbranch.html',
                controller: 'DashboardCtrl'
            })
            .when('/dashboard', {
                templateUrl: './views/dashboard/dashboard.html',
                controller: 'DashboardCtrl'
            })
            .when('/branch', {
                templateUrl: './views/devloper/branch/branch.html',
                controller: 'BranchCtrl'
            })
            .when('/recoverBranch', {
                templateUrl: './views/devloper/branch/recoverbranch.html',
                controller: 'RecoverBranchCtrl'
            })
            .otherwise({
                redirectTo: '/'
            });
        $httpProvider
            .interceptors.push('LocalStorageInterceptor');
    })
    .factory('LocalStorageInterceptor', function ($q, $location, $injector) {
        return {
            request: function (config) {
                config.headers = config.headers || {};
                var LocalStorageService = $injector.get('LocalStorageService');
                if (LocalStorageService.isAuthenticated()) {
                    config.headers.Authorization = 'Bearer ' + LocalStorageService.getToken();
                }
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        };
    })
    .directive("navbarMenu", function () {
        return {
            restrict: "E",
            templateUrl: "./views/shared/navbar/navbar.html"
        }
    })
    .directive("sidebarMenu", function () {
        return {
            restrict: "E",
            templateUrl: "./views/shared/sidebar/sidebar.html"
        }
    })
