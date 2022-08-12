using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyRestaurant.Web.Models
{
    [Table(name: "OrderDetails")]
    public partial class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order Detail ID")]
        public int OrderDetailId { get; set; }

        #region

        virtual public int OrderId { get; set; }
        [ForeignKey(nameof(OrderDetail.OrderId))]
        public Order Order { get; set; }


        #endregion
    }
}
