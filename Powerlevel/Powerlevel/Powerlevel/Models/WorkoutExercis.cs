namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkoutExercises")]
    public partial class WorkoutExercis
    {
        [Key]
        public int LinkId { get; set; }

        public int WorkoutId { get; set; }

        public int ExerciseId { get; set; }

        public int? OrderNumber { get; set; }

        public virtual Exercis Exercis { get; set; }

        public virtual Workout Workout { get; set; }
    }
}
