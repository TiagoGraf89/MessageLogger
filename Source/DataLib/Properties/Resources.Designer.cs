﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLib.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DataLib.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select *,
        ///case 
        ///	when DaySupply &gt; 90 then 1
        ///	when DaySupply between 45 and 90 then 2
        ///	when DaySupply &lt; 45 then 3 end as Indicator
        ///from 
        ///(
        ///	select 
        ///	*, 
        ///	case when Data.Sold - Data.Inventory &lt; 0 THEN 0 
        ///	else Data.Sold - Data.Inventory END as OrderQuantity,
        ///	convert(int, (convert(decimal(10,2),Data.Inventory) / convert(decimal(10,2),Data.Sold) * 90.00)) DaySupply
        ///	from
        ///	(
        ///		   select v.VehicleMake, v.VehicleModel, count(1) Sold,
        ///		   (
        ///				  select count(1) 
        ///				  from dmsd.VehicleInventory  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ForecastQuery {
            get {
                return ResourceManager.GetString("ForecastQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @table table (M int);
        ///insert @table values (1);
        ///insert @table values (2);
        ///insert @table values (3);
        ///insert @table values (4);
        ///insert @table values (5);
        ///insert @table values (6);
        ///insert @table values (7);
        ///insert @table values (8);
        ///insert @table values (9);
        ///insert @table values (10);
        ///insert @table values (11);
        ///insert @table values (12);
        ///
        ///select data.Month, max(quantity) Quantity
        ///from
        ///(
        ///	select 
        ///		datepart(m,DmsSoldDate) Month ,count(0) as Quantity 
        ///	from dmsd.Deals d
        ///	join dmsd.Veh [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SalesHistoryQuery {
            get {
                return ResourceManager.GetString("SalesHistoryQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///SELECT count(*)/( SELECT count(*)/90.00  as StockDaysLasting
        ///					FROM dsmd.deals
        ///					where NewUsedTypeId = 2 and DmsSoldDate&gt; &apos;2016-03-03&apos; ) 
        ///FROM [CARDB].[dbo].[VehicleInventory] where  NewUsedType = &apos;New&apos;.
        /// </summary>
        internal static string StockDaysLasting {
            get {
                return ResourceManager.GetString("StockDaysLasting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///SELECT count(*)  as TotalInStock FROM dmsd.VehicleInventory where  NewUsedType = &apos;New&apos;.
        /// </summary>
        internal static string TotalInStock {
            get {
                return ResourceManager.GetString("TotalInStock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT CASE WHEN MONTH &lt; 7 THEN CONVERT(DATETIME,&apos;2016-&apos; +CONVERT(VARCHAR(2), Month) + &apos;-01&apos;) ELSE  CONVERT(DATETIME,&apos;2015-&apos; +CONVERT(VARCHAR(2), Month) + &apos;-01&apos;) END Date ,Quantity FROM (
        /// 
        ///      select 
        ///	datepart(m,DmsSoldDate) Month ,count(0) as Quantity 
        ///from dmsd.Deals d
        ///join dmsd.Vehicles v on v.LoopVehicleId = d.LoopVehicleId
        ///group by datepart(m,DmsSoldDate)
        ///) A order by date.
        /// </summary>
        internal static string TotalSelledByMonthGrouped {
            get {
                return ResourceManager.GetString("TotalSelledByMonthGrouped", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT sum(dealercost) as TotalValueOfVehicles  FROM dmsd.VehicleInventory where  NewUsedType = &apos;New&apos;.
        /// </summary>
        internal static string TotalValueOfVehicles {
            get {
                return ResourceManager.GetString("TotalValueOfVehicles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///SELECT sum(dealercost)/count(dealercost) as VehicleAverageValue FROM dmsd.VehicleInventory where  NewUsedType = &apos;New&apos;
        ///.
        /// </summary>
        internal static string VehicleAverageValue {
            get {
                return ResourceManager.GetString("VehicleAverageValue", resourceCulture);
            }
        }
    }
}
