(function () {
    'use strict';

    angular
        .module('ms')
        .factory('auth', auth);

    auth.$inject = ['$http', '$q', 'apiCollection'];
    function auth($http, $q, apiCollection) {


        var service = {
            authenticate: authenticate
        };

        return service;

        ////////////////
        function authenticate(data) {
            var defer = $q.defer();
            $http.post(apiCollection.auth.login(), data).then(function (response) {
                if (response.data.success) {
                    sessionStorage.setItem('userDetails', JSON.stringify(response.data));
                }
                    defer.resolve(response.data);
            })
            return defer.promise;
        }
    }
})();