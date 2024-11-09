namespace SupermarketWEB.Models
{
    public class Providers
    {
        public int Id { get; set; } // será la llave primaria
        public int Document { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Addres { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
