(function() {
    'use strict';

    angular
        .module('ms')
        .factory('loginFactory', loginFactory);

    loginFactory.$inject = ['auth'];
    function loginFactory(auth) {
        var service = {
            login:login
        };
        
        return service;

        ////////////////
        function login(user) {
            return auth.authenticate(user)
         }
    }
})();