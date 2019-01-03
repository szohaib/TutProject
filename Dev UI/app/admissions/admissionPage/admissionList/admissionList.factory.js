(function () {
    'use strict';

    angular
        .module('ms')
        .factory('admissionListFactory', admissionListFactory);

    admissionListFactory.$inject = ['$http', '$q', 'apiEndPoint','apiCollection'];
    function admissionListFactory($http, $q, apiEndPoint,apiCollection) {
        var admissionData = [];
// {
//             "admissionNumber": "0001",
//             "studentName": "Mohammed Azhar uddin",
//             "branchName": "Masabtank",
//             "academicYear": "2018",
//             "cgpA_Per": "8.5"
//         }, {
//             "admissionNumber": "0002",
//             "studentName": "Abdul Aleem",
//             "branchName": "Tolichowki",
//             "academicYear": "2017",
//             "cgpA_Per": "9.8"
//         }
        var service = {
            getAdmissionList: getAdmissionList,
            getAdmissionGridOptions: getAdmissionGridOptions
        };

        return service;

        ////////////////

        /* Call to server to get enquiry list
         dataRowStructure : {

         }*/
        function getAdmissionList() {
            var defer = $q.defer();
            if (admissionData.length === 0) {
                $http.get(apiCollection.admission.getAllByUserIdUrl(JSON.parse(sessionStorage.userDetails).data.userId)).then(function (result) {
                    admissionData = result.data.table;
                    defer.resolve(result.data.table);
                });
            } else {
                defer.resolve(admissionData);
            }

            return defer.promise;
        }
        function getAdmissionGridOptions() {
            return {
                columns: [
                    { title: "Admission No.", data: "admissionNo" },
                    { title: "Student Name", data: "studentName" },
                    { title: "Branch Name", data: "branchName" },
                    { title: "Course", data: "courseName" },
                    { title: "Status", data: "status" },
                    { title: "Assigned To", data: "assignedTo" },
                    { title: "Action" }
                ],
                columnDefs: [
                    {
                        targets: 6,
                        title: "Action",
                        render: function () {
                            return '<a role="button" class="btn btn-simple btn-warning btn-icon edit"><i class="material-icons">mode_edit</i></a>';
                        }
                    }
                ],
                pagingType: "full_numbers",
                lengthMenu: [
                    [10, 25, 50],
                    [10, 25, 50]
                ],
                responsive: true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Search records",
                }
                // dom: 'lfBrtip',
                // buttons: [
                //     {
                //         text: 'Add',
                //         action: function (e, dt, node, config) {
                //             alert('Button activated');
                //         }
                //     }
                // ]
            }
        }
    }
})();