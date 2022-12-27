using CorePronia.Entities;

namespace WebApplication1.ViewModels;

public class HomeVM
{
    public IEnumerable<SlideItem> SlideItems { get; set; }
    public IEnumerable<ShippingItem> ShippingItems { get; set; }
}
