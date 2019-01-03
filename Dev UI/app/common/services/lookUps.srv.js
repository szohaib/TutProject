(function () {
    'use strict';

    angular
        .module('ms')
        .factory('lookUps', lookUps);

    lookUps.$inject = ['apiCollection', '$http'];
    function lookUps(apiCollection, $http) {
        var lookUpData = {};
        var lookUpsLoaded = false;

        var service = {
            loadLookUps: loadLookUps,
            getZones: getZones,
            getCourses: getCourses,
            getQualifyingExams: getQualifyingExams,
            getYearOfPassing: getYearOfPassing,
            getBranches: getBranches,
            getEducationGroups:getEducationGroups,
            getGroupNameBasedOnCourseId:getGroupNameBasedOnCourseId,
            isLookUpsLoaded:function() {
                return lookUpsLoaded;
            }
        };

        return service;

        function loadLookUps() {
            if (sessionStorage.userDetails)
                return $http.get(apiCollection.lookUps.getByUserId(JSON.parse(sessionStorage.userDetails).data.userId)).then(function (response) {
                    lookUpData = response.data;
                    lookUpsLoaded = true;
                })
        }

        ////////////////
        function getZones() {
            return lookUpData.zones;
        }
        function getBranches() {
            return lookUpData.branches;
        }
        function getCourses(group) {
            if (lookUpData.educationCourse) {
                return lookUpData.educationCourse.filter(function (item) {
                    return item.groupName === group;
                })
            } else {
                return false;
            }
        }
        function getGroupNameBasedOnCourseId (courseId) {
            return lookUpData.educationCourse.filter(function(item) {
                return item.courseId === courseId
            })[0].groupName;
        }
        function getEducationGroups() {
            return lookUpData.educationGroups;
        }
        function getEducationLevels() {
            return lookUpData.educationLevels;
        }
        function getInstitutionTypes() {
            return lookUpData.institutionTypes;
        }
        function getQualifyingExams(educationLevel) {
            if (lookUpData.qualifyingExams) {
                return lookUpData.qualifyingExams.filter(function (item) {
                    return item.educationLevelId === educationLevel;
                })
            }
            else {
                return false;
            }
        }
        function getSecondLanguages() {
            return lookUpData.secondLanguage;
        }
        function getYearOfPassing() {
            var years = [];
            var date = (new Date());
            for (var index = 0; index < 5; index++) {
                years.push(new Date().getFullYear() - index);
            }
            return years;
        }
    }
})();