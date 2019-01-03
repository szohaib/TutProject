(function () {
    'use strict';

    angular
        .module('ms')
        .factory('admissionFactory', admissionFactory);

    admissionFactory.$inject = ['$q','$http','apiCollection'];
    function admissionFactory($q,$http,apiCollection) {
        var admissionData = {};
        var service = {
            getAdmission: getAdmission,
            getCourses: getCourses
        };

        return service;

        ////////////////
        function getAdmission(educationLevelId,id,userId) {
            var defer = $q.defer();
            if (admissionData.id !== id) {
                $http.get(apiCollection.admission.getByIds(educationLevelId,id,userId)).then(function (result) {
                    admissionData = result.data.table[0];
                    defer.resolve(result.data.table[0]);
                });
            } else {
                defer.resolve(admissionData);
            }

            return defer.promise;
        }
        function getCourses(educationLevel) {
            if (educationLevel === 'junior') {
                return [{
                    "courseName": "MPC",
                    "subCourses": [{
                        "name": "Regular",
                        "courseId": 1
                    }, {
                        "name": "IIT-Mains",
                        "courseId": 2
                    }, {
                        "name": "FTB",
                        "courseId": 3
                    }]
                }, {
                    "courseName": "BiPC",
                    "subCourses": [{
                        "name": "Regular",
                        "courseId": 4
                    }, {
                        "name": "NEET",
                        "courseId": 5
                    }, {
                        "name": "FTB",
                        "courseId": 6
                    }]
                }, {
                    "courseName": "MEC",
                    "subCourses": [{
                        "name": "Regular",
                        "courseId": 7
                    }, {
                        "name": "CPT",
                        "courseId": 8
                    }]
                }, {
                    "courseName": "CEC",
                    "subCourses": [{
                        "name": "Regular",
                        "courseId": 9
                    }]
                }]
            } else if (educationLevel === 'degree') {
                return [{
                    "courseName": "B.Sc.",
                    "subCourses": [{
                        "name": "B.Sc.(MPCs)",
                        "courseId": 1
                    }, {
                        "name": "B.Sc.(MPC)",
                        "courseId": 2
                    }, {
                        "name": "B.Sc.(BZC)",
                        "courseId": 3
                    }]
                }, {
                    "courseName": "B.Com",
                    "subCourses": [{
                        "name": "B.Com(Regular)",
                        "courseId": 4
                    }, {
                        "name": "B.Com(Computers)",
                        "courseId": 5
                    }]
                }, {
                    "courseName": "B.A.",
                    "subCourses": [{
                        "name": "B.A.(P.L.P)",
                        "courseId": 7
                    }, {
                        "name": "B.A.(E.P.P.)",
                        "courseId": 8
                    }]
                }]
            }
        }
    }
})();