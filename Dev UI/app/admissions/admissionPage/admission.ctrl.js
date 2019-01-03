(function () {
    'use strict';

    angular
        .module('ms')
        .controller('admissionCtrl', addadmissionCtrl);

    addadmissionCtrl.$inject = ['$scope', '$stateParams', 'admissionFactory', '$timeout', '$state'];
    function addadmissionCtrl($scope, $stateParams, admissionFactory, $timeout, $state) {
        $scope.admission = {};
        $scope.admission.academicYear = (new Date()).getFullYear();
        $scope.yearsOfPassing = lookUps.getYearOfPassing();

        activate();

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
            if ($scope.enquiry.educationLevelId) {
                $scope.exams = lookUps.getQualifyingExams($scope.enquiry.educationLevelId);
                $scope.groups = lookUps.getEducationGroups();
                var courses = [];
                for (var index = 0; index < $scope.groups.length; index++) {
                    courses.push({
                        groupName: $scope.groups[index].name,
                        courses: lookUps.getCourses($scope.groups[index].name)
                    })

                }
                // $scope.mpcCourses = lookUps.getCourses("MPC");
                // $scope.bpcCourses = lookUps.getCourses("BPC");
                // $scope.mecCourses = lookUps.getCourses("MEC");
                // $scope.cecCourses = lookUps.getCourses("CEC");
                // $scope.schoolCourses = lookUps.getCourses("Class");
            }
        }

        ////////////////

        $scope.submit = function () {
            var text = '';
            if ($scope.mode === 'Add') {
                text = 'added';
            } else {
                text = 'saved';
            }
            swal({
                title: "Success!",
                text: "Enquiry was " + text + " successfully!",
                buttonsStyling: false,
                confirmButtonClass: "btn btn-success",
                type: "success"
            }).then(function () {
                $state.go('main.admissionList');
            }).catch(swal.noop)
        }

        $scope.cancel = function () {
            swal({
                title: 'Are you sure you want to cancel?',
                text: "All your changes will be lost",
                type: 'warning',
                showCancelButton: true,
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger',
                confirmButtonText: 'Yes, Cancel it!',
                cancelButtonText: 'No, Stay on the page',
                buttonsStyling: false
            }).then(function () {
                $state.go('main.admissionList');
            }).catch(swal.noop)
        }
        // $scope.educationLevelChange = function(){
        //     $timeout(function(){//need to find another solution
        //         $scope.courses = admissionFactory.getCourses($scope.enquiry.educationLevelId);            
        //     })
        // }

        function activate() {
            if ($stateParams.mode === 'edit') {
                $scope.mode = 'Save';
                $scope.header = 'Update an existing enquiry'
                admissionFactory.getAdmission($stateParams.educationLevelId, $stateParams.id, $stateParams.userId).then(function (data) {
                    $scope.admission = data;
                });
                // $scope.courses = admissionFactory.getCourses($scope.enquiry.educationLevelId);
            } else {
                $scope.mode = 'Add';
                $scope.header = 'Add a new admission'

            }
        }
    }
})();