(function () {
    'use strict';

    angular.module('ms')
        .config(routeConfig);

    function routeConfig($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state({
                name: 'login',
                url: '/login',
                templateUrl: 'app/login/login.html',
                controller:'loginCntrl'
            })
            .state({
                name: 'main',
                abstract:true,
                templateUrl: 'app/layout/layout.html',
                controller:'layoutCtrl'
            })
            
         $urlRouterProvider.otherwise("login")
    }
})();