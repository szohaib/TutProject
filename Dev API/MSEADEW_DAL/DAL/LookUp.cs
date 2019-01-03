using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEADEW_DAL.DAL
{
   public class LookUp
    {
        public List<Address> address { get; set; }
        public List<Zone> zones { get; set; }
        public List<EducationLevel> educationLevels { get; set; }
        public List<AddressType> adressTypes { get; set; }
        public List<Branch> branches { get; set; }
        public List<Category> category { get; set; }
        public List<Course> courses { get; set; }
        public List<Group> groups { get; set; }
        public List<Guardian> guardian { get; set; }
        public List<InstitutionType> institutionTypes { get; set; }
        public List<QualifyingExam> qualifyingExam { get; set; }
        public List<SecondLanguage> secondLang { get; set; }
        public List<Status> status { get; set; }
    }
    public class Address
    {
        public int id { get; set; }
        public string addressType { get; set; }
        public string streetAddress { get; set; }
        public string landmark { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
    public class Zone
    {
        public int id { get; set; }
        public string addressType { get; set; }
    }
    public class EducationLevel
    {

        public int id { get; set; }
        public string name { get; set; }
    }

    public class AddressType
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Branch
    {
        public int id { get; set; }
        public string name { get; set; }
        public int zoneId { get; set; }
        public int institutionTypeId { get; set; }
        public string branchName { get; set; }
    }
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public int educationLevelId { get; set; }
    }
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int groupId { get; set; }
    }
    public class Guardian
    {
        public int id { get; set; }
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public string Email { get; set; }
        public string qualification { get; set; }
        public string occupation { get; set; }
        public string fPhone { get; set; }
        public string mPhone { get; set; }
        public int addressId { get; set; }
    }
    public class InstitutionType
    {     
        public int id { get; set; }
        public string name { get; set; }
        public int educationLevelId { get; set; }
    }
    public class QualifyingExam
    {
        public int id { get; set; }
        public string name { get; set; }
        public int educationLevelId { get; set; }
    }
    public class SecondLanguage
    {    
        public int id { get; set; }
        public string name { get; set; }
        public int educationLevelId { get; set; }
    }
    public class Status
    {
        public int id { get; set; }
        public string name { get; set; }
    }
   
}
