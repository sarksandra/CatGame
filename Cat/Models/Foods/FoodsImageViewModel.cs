namespace Cat.Models.Foods
{
	public class FoodsImageViewModel
	{
		public Guid ImageID { get; set; }
		public string ImageTitle { get; set; }
		public byte[] ImageData { get; set; }
		public string Image { get; set; }
		public Guid? FoodID { get; set; }

	}
}
