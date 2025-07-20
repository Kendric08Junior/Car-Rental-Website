namespace Car_Rentel.Models
{
    public class CarRental
    {
        public int Id { get; set; }
        public string CarModel { get; set; }               
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Reason { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public string PickupLocation { get; set; }
        public string Destination { get; set; }
        public string Purpose { get; set; }
        public int NumberOfPassengers { get; set; }
        public string AdditionalRequests { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}