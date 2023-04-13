﻿namespace FirstApplication.Models
{
  public class Customer
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsSubcribedToNewsletter { get; set; }
    public MembershipType MembershipType { get; set; }
    public byte MemberShipTypeId { get; set; }
  }
}
