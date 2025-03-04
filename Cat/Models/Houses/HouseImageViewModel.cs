namespace Cat.Models.Realms
{
	public class HouseImageViewModel
	{
		public Guid ImageID { get; set; }
		public string ImageTitle { get; set; }
		public byte[] ImageData { get; set; }
		public string Image { get; set; }
		public Guid? RealmID { get; set; }

	}
}
