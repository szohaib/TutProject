
(function () {
    'use strict';

    angular
        .module('ms')
        .factory('apiCollection', apiCollection);

    apiCollection.$inject = ['apiEndPoint'];
    function apiCollection(apiEndPoint) {
        var enquiry = {
            getAllByUserIdUrl: function (userId) {
                return apiEndPoint + "api/Enquiry/GetAllEnquiryDetails?userId=" + userId;
            },
            getById: function (id) {
                return apiEndPoint + "api/Enquiry/GetEnquiryDetailsById?enquiryId=" + id;
            },
            update: function () {
                return apiEndPoint + "api/Enquiry/UpdateEnquiry";
            }
        }
        var admission = {
            getAllByUserIdUrl: function (userId) {
                return apiEndPoint + "api/Admission/GetAllAdmissionDetails?userId=" + userId;
            },
            getByIds: function (educationLevelId, admissionId, userId) {
                return apiEndPoint + "api/Admission/GetAdmissionDetailsById?educationLevelId=" + educationLevelId + "&admissionId=" + admissionId + "&userId=" + userId;
            },
            update: function () {
                return apiEndPoint + "api/Enquiry/UpdateAdmission";
            }
        }
        var auth = {
            login: function () {
                return apiEndPoint + "api/Login/ValidateUser";
            }
        }

        var lookUps = {
            getByUserId: function (userId) {
                return apiEndPoint + "api/Lookup/GetAllLookup?userId="+userId
            }
        }

        var feeStructure = {
            getByIds: function (educationLevelId , branchId , userId){
                return apiEndPoint + "api/FeeStructure/GetAllFeeStructure?educationLevelId=" + educationLevelId + "&branchId=" + branchId + "&userId=" + userId;
            }
        }

        return {
            enquiry: enquiry,
            auth: auth,
            admission: admission,
            lookUps:lookUps,
            feeStructure : feeStructure
        };

    }
})();


