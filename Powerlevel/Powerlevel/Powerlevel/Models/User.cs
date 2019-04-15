namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            UserCurrWorkouts = new HashSet<UserCurrWorkout>();
        }

        public int UserId { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCurrWorkout> UserCurrWorkouts { get; set; }
    }
}
