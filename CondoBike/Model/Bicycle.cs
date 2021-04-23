using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CondoBike.Model
{
    [Table("BICYCLES")]
    public class Bicycle
    {
        [Key]
        [Column("ID")]
        public int BicycleID;

        [Column("OWNER")] 
        public Owner BicycleOwner {get ; set;}

        [Column ("COLOR")]
        public string BicycleColor {get; set;}

        [Column("NICKNAME")]
        public string BicycleNickName {get ; set;}

        [Column("IDENTIFICATION")]
        public string BicycleStorageIdentification {get ; set; }

        [Column("STORAGE")]
        public BicycleStorage BicycleStorage {get ; set ;}

        [Column("STATUS")]
        public BicycleStatus BicycleStatus {get ; set; }


        public bool HasOwner()
        {
            return BicycleOwner == null ? false : true;
        }

        public bool HasIdentification()
        {
            return !String.IsNullOrEmpty(BicycleStorageIdentification);
        }
        
    }

    public enum BicycleStatus
    {

        Guarded = 1,
        NotGuarded = 0,
        Cancelled = 2

    }
}