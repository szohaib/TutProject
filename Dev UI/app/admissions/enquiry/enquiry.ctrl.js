(function () {
    'use strict';

    angular
        .module('ms')
        .controller('enquiryCtrl', addEnquiryCtrl);

    addEnquiryCtrl.$inject = ['$scope', '$stateParams', 'enquiryFactory', '$timeout', '$state', 'lookUps'];
    function addEnquiryCtrl($scope, $stateParams, enquiryFactory, $timeout, $state, lookUps) {
        $scope.enquiry = {};
        $scope.enquiry.academicYear = (new Date()).getFullYear();
        $scope.yearsOfPassing = lookUps.getYearOfPassing();

        activate();

        ////////////////

        function waitForLookUps() {
            if (lookUps.isLookUpsLoaded()) {
                getLookUps();
            }
            else {
                $scope.$on('lookUpsLoaded', function () {
                    getLookUps();
                })
            }

        }
        function getLookUps() {
            $scope.branches = lookUps.getBranches();
            $scope.groups = lookUps.getEducationGroups();
                if($scope.enquiry.courseId){
                    $scope.enquiry.groupName = lookUps.getGroupNameBasedOnCourseId($scope.enquiry.courseId);
                    $scope.courses = lookUps.getCourses($scope.enquiry.groupName);
                }
            if ($scope.enquiry.educationLevelId) {
                $scope.exams = lookUps.getQualifyingExams($scope.enquiry.educationLevelId);
            }
        }
        $scope.groupSelected = function() {
            $scope.courses = lookUps.getCourses($scope.enquiry.groupName);
        }

        $scope.submit = function () {
            enquiryFactory.submit($scope.mode, $scope.enquiry, $scope.enquiryForm);
        }

        $scope.cancel = function () {
            enquiryFactory.showCancelAlert();
        }
        $scope.educationLevelChange = function () {
            $timeout(function () {//need to find another solution
                $scope.exams = lookUps.getQualifyingExams($scope.enquiry.educationLevelId);
                $scope.levelSelected = true;
            })
        }

        function activate() {
            if ($stateParams.mode !== 'add') {
                if ($stateParams.mode === 'view') {
                    $scope.mode = 'View';
                    $scope.header = 'View an existing enquiry'
                } else {
                    $scope.mode = 'Save';
                    $scope.header = 'Update an existing enquiry'
                }
                enquiryFactory.getEnquiry($stateParams.id).then(function (data) {
                    $scope.enquiry = data;
                    // $scope.enquiryDataLoaded = true;
                    waitForLookUps();

                });
            } else {
                $scope.mode = 'Add';
                $scope.header = 'Add a new enquiry'
                waitForLookUps();
            }
        }
    }
})();