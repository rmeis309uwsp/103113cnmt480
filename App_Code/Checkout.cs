using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Checkout
/// </summary>
public class Checkout
{
    public int itemId { get; set; }
    public string personUwspId { get; set; }
    public string personRole { get; set; }
    public string personEmail { get; set; }
    public string personPhone { get; set; }
    public string personFName { get; set; }
    public string personLName { get; set; }
    public string purpose { get; set; }
    public DateTime? dueDate { get; set; }
    public DateTime? checkOutDate { get; set; }
    public DateTime? checkInDate { get; set; }
    public DateTime requestSentDate { get; set; }
    public DateTime requestedForDate { get; set; }
    public bool agreementSigned { get; set; }
    public bool activeCheckout { get; set; }
    public bool activeRequest { get; set; }

    public Checkout(int itemId, string personUwspId, string personRole, string personEmail, string personPhone,
        string personFName, string personLName, string purpose, DateTime? dueDate, DateTime? checkOutDate, DateTime? checkInDate, DateTime requestSentDate, DateTime requestedForDate, bool aggreementSigned,
        bool activeCheckout, bool activeRequest)
    {
        this.itemId = itemId;
        this.personUwspId = personUwspId;
        this.personRole = personRole;
        this.personEmail = personEmail;
        this.personPhone = personPhone;
        this.personFName = personFName;
        this.personLName = personLName;
        this.purpose = purpose;
        this.dueDate = dueDate;
        this.checkOutDate = checkOutDate;
        this.checkInDate = checkInDate;
        this.requestSentDate = requestSentDate;
        this.requestedForDate = requestedForDate;
        this.agreementSigned = agreementSigned;
        this.activeCheckout = activeCheckout;
        this.activeRequest = activeRequest;
    }
}