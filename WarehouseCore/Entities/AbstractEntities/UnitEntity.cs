namespace WarehouseCore.Entities.AbstractEntities;

public abstract class UnitEntity
{
   protected UnitEntity(string unit)
   {
      Unit = unit.Length == 2 ? unit : throw new Exception("unit of measure should have two characters");
   }

   public string Unit { get; set; } 
}