﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinoPoisk.DomainLayer.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MovieResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MovieResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("KinoPoisk.DomainLayer.Resources.MovieResource", typeof(MovieResource).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid description value. The length of the movie description should not exceed 500 characters.
        /// </summary>
        public static string DescriptionExceedsMaxLen {
            get {
                return ResourceManager.GetString("DescriptionExceedsMaxLen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect budget value.
        /// </summary>
        public static string IncorrectBudget {
            get {
                return ResourceManager.GetString("IncorrectBudget", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect duration value.
        /// </summary>
        public static string IncorrectDuration {
            get {
                return ResourceManager.GetString("IncorrectDuration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect premiere date.
        /// </summary>
        public static string IncorrectPremiereDate {
            get {
                return ResourceManager.GetString("IncorrectPremiereDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect world fees.
        /// </summary>
        public static string IncorrectWorldFees {
            get {
                return ResourceManager.GetString("IncorrectWorldFees", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Argument is null.
        /// </summary>
        public static string NullArgument {
            get {
                return ResourceManager.GetString("NullArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid movie title value. The length of the movie title should not exceed 100 characters.
        /// </summary>
        public static string TitleExceedsMaxLen {
            get {
                return ResourceManager.GetString("TitleExceedsMaxLen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid movie title value. The minimum length of the title is 2.
        /// </summary>
        public static string TitleLessMinLen {
            get {
                return ResourceManager.GetString("TitleLessMinLen", resourceCulture);
            }
        }
    }
}
