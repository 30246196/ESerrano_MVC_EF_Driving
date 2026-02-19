using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;// added for [Key] attribute
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESerrano_MVC_EF_Driving.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }//Primary Key
        public DateTime Date_Became_Customer { get; set; }
        public DateTime Date_Of_Birth  { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public decimal Ammount_Outstanding { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Cell_Mobile_Phone_Number { get; set; }
        public string Other_Customer_Details { get; set; }

        // Navigation properties
        [ForeignKey("Address")]
        public int? AddressID { get; set; }//A customer may not have an address, so AddressId is nullableFK to Address 
        public Address Address { get; set; }  

        [ForeignKey("Ref_Customer_Status")]       
        public int Customer_Status_Code { get; set; }// FK to Ref_Customer_Status

        public List<Customer_Payments> Customer_Payment { get; set; } // A customer can have multiple payments

        public List<Lesson> Lessons { get; set; }// A customer can have multiple lessons
    }

    public class Ref_Customer_Status
    { 
        public int Customer_Status_Code { get; set; }
        public string Customer_Status_Description { get; set; }

        // Navigation properties
        public List<Customer> Customers { get; set; } // A customer status can be associated with multiple customers
    }

    public class Customer_Payments
    {
        //this class has a composite key: CustomerId and Datetime_Payment

        //A Customer_payment has one Customer
        //This is the first part of the composite key
        [Key, Column(Order = 0),ForeignKey("Customer")]//Composite Key part 1 and FK to Customer
        public int CustomerID { get; set; }//primary Key and FK to Customer

        [Key, Column(Order = 1)]////This is the second part of the composite key
        public DateTime DateTime_Payment { get; set; }// Primary Key
        
        public decimal Amount_Payment { get; set; }
        public string Other_Payment_Details{ get; set; }

        // Navigation properties
        [ForeignKey("Ref_Payment_Methods")]
        public int Payment_Method_Code { get; set; } // FK to Ref_Payment_Method
        public Ref_Payment_Method Ref_Payment_Methods { get; set; } // Navigation property to Ref_Payment_Method


    }

    public class Ref_Payment_Method
    {
        [Key]
        public int Payment_Method_Code { get; set; }
        public string Payment_Method_Description { get; set; }

        // Navigation properties
        public List<Customer_Payments> Customer_Payments { get; set; } // A payment method can be associated with multiple customer payments
    }

    public class  Address
    {
        [Key]
        public int AddressID { get; set; }
        public string Building_Number { get; set; }
        public string Street_Name { get; set; }      
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Other_Address_Details { get; set; }

        // Navigation properties
        List<Customer> Customers { get; set; } // An address can be associated with multiple customers
        List<Staff> Staff { get; set; } // An address can be associated with multiple staff members

    }
    public class Staff//
    {
        [Key]
        public int StaffID { get; set; }
        public string Nickname { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public DateTime Date_Joined_Staff { get; set; }
        public DateTime? Date_Left_Staff { get; set; }
        public string Other_Staff_Details { get; set; }

        // Navigation properties
        [ForeignKey("Address")]
        public int? AddressID { get; set; } // A staff member may not have an address, so AddressId is nullableFK to Address
        public Address Address { get; set; } // Navigation property to Address

        List<Lesson> Lessons { get; set; } // A staff member can have multiple lessons
    }

    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        public DateTime Lesson_Date { get; set; }
        public DateTime Lesson_Time { get; set; }      
        public decimal Price { get; set; }
        public string Other_Lesson_Details { get; set; }

        // Navigation properties
        [ForeignKey("Customer")]
        public int CustomerID { get; set; } // FK to Customer
        public Customer Customer { get; set; } // Navigation property to Customer

        [ForeignKey("Staff")]
        public int StaffID { get; set; } // FK to Staff
        public Staff Staff { get; set; } // Navigation property to Staff

        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; } // FK to Vehicle
        public Vehicle Vehicle { get; set; } // Navigation property to Vehicle

        [ForeignKey("Ref_Lesson_Status")]
        public int Lesson_Status_Code { get; set; } // FK to Ref_Lesson_Status
        public Ref_Lesson_Status Ref_Lesson_Status { get; set; } // Navigation property to Ref_Lesson_Status

    }
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Vehicle_Details    { get; set; }
        // Navigation properties
        List<Lesson> Lessons { get; set; } // A vehicle can be associated with multiple lessons

    }

    public class Ref_Lesson_Status
    {
        public int Lesson_Status_Code { get; set; }
        public string Lesson_Status_Description { get; set; }
        // Navigation properties
        List<Lesson> Lessons { get; set; } // A lesson status can be associated with multiple lessons

    }



}