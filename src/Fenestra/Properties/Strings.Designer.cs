﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BadEcho.Fenestra.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BadEcho.Fenestra.Properties.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to A single attachable component instance cannot target more than one target dependency object..
        /// </summary>
        internal static string AttachableCannotTargetMultipleObjects {
            get {
                return ResourceManager.GetString("AttachableCannotTargetMultipleObjects", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Behavior is already attached to the target dependency object..
        /// </summary>
        internal static string BehaviorAlreadyAttachedToTarget {
            get {
                return ResourceManager.GetString("BehaviorAlreadyAttachedToTarget", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This behavior only supports attachment to target objects of type &apos;{0}&apos;..
        /// </summary>
        internal static string BehaviorUnsupportedTargetObject {
            get {
                return ResourceManager.GetString("BehaviorUnsupportedTargetObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred during a data binding action..
        /// </summary>
        internal static string BindingActionError {
            get {
                return ResourceManager.GetString("BindingActionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot add non-binding related data to multi-binding collection..
        /// </summary>
        internal static string CannotAddNonBindingToMultiBinding {
            get {
                return ResourceManager.GetString("CannotAddNonBindingToMultiBinding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can only convert Fenestra specific resource key types..
        /// </summary>
        internal static string CanOnlyConvertFenestraKeys {
            get {
                return ResourceManager.GetString("CanOnlyConvertFenestraKeys", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insertion of a view model into a child view model collection can only be done if valid model data has been bound to the child view model..
        /// </summary>
        internal static string CollectionChildBindingRequiresActiveModel {
            get {
                return ResourceManager.GetString("CollectionChildBindingRequiresActiveModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removal of a view model from a child view model collection whose model data is still bound to the collection view model can only be done while the child view model still has valid model data bound to it..
        /// </summary>
        internal static string CollectionChildUnbindingRequiresActiveModel {
            get {
                return ResourceManager.GetString("CollectionChildUnbindingRequiresActiveModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The collection view model engine requires a valid collection property change handler to be specified in the provided options..
        /// </summary>
        internal static string CollectionViewModelEngineRequiresHandler {
            get {
                return ResourceManager.GetString("CollectionViewModelEngineRequiresHandler", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Either an invalid parameter was provided to a command, or the command was not in a state where execution was permitted..
        /// </summary>
        internal static string CommandCannotExecute {
            get {
                return ResourceManager.GetString("CommandCannotExecute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple copies of bound data assigned to children view models in a collection view model were encountered. Bound data should be distinctly represented by a single view model amongst the children of a collection view model..
        /// </summary>
        internal static string DuplicateModelInCollectionViewModel {
            get {
                return ResourceManager.GetString("DuplicateModelInCollectionViewModel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Fenestra dispatcher must be shut down due to an unhandled error caused by one of its components..
        /// </summary>
        internal static string FenestraDispatcherError {
            get {
                return ResourceManager.GetString("FenestraDispatcherError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Fenestra dispatcher has been manually shutdown..
        /// </summary>
        internal static string FenestraDispatcherManuallyShutdown {
            get {
                return ResourceManager.GetString("FenestraDispatcherManuallyShutdown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fenestra resource key descriptor does not describe a locatable field on a key provider..
        /// </summary>
        internal static string FenestraKeyCannotFindField {
            get {
                return ResourceManager.GetString("FenestraKeyCannotFindField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fenestra resource key descriptor does not describe a locatable provider type..
        /// </summary>
        internal static string FenestraKeyCannotFindType {
            get {
                return ResourceManager.GetString("FenestraKeyCannotFindType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fenestra resource key descriptor is invalid..
        /// </summary>
        internal static string FenestraKeyIsInvalid {
            get {
                return ResourceManager.GetString("FenestraKeyIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An attempt to bind a data context of an incompatible type to a context-specific Fenestra window was made..
        /// </summary>
        internal static string IncompatibleDataContextType {
            get {
                return ResourceManager.GetString("IncompatibleDataContextType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Thickness value with an illegal number of lengths was provided. A Thickness value can only have 1, 2, or 4 lengths..
        /// </summary>
        internal static string JsonThicknessInvalidThickness {
            get {
                return ResourceManager.GetString("JsonThicknessInvalidThickness", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A stepped binding requires the value for the property &apos;{0}&apos; to be able to be converted to a 32-bit signed integer..
        /// </summary>
        internal static string NotSteppablePropertyValue {
            get {
                return ResourceManager.GetString("NotSteppablePropertyValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An outlined text element control was provided with an improper format string: {0}.
        /// </summary>
        internal static string OutlinedTextBadFormatString {
            get {
                return ResourceManager.GetString("OutlinedTextBadFormatString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pack URIs pointing to a referenced assembly resource file require the name of the assembly, which the provided assembly lacks..
        /// </summary>
        internal static string PackUriRequiresAssemblyName {
            get {
                return ResourceManager.GetString("PackUriRequiresAssemblyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This window message handler hook has already been registered with the Presentation window wrapper..
        /// </summary>
        internal static string PresentationWindowWrapperDuplicateHook {
            get {
                return ResourceManager.GetString("PresentationWindowWrapperDuplicateHook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The imported resource URI &apos;{0}&apos; is not a ResourceDictionary..
        /// </summary>
        internal static string ResourceUriNotResourceDictionary {
            get {
                return ResourceManager.GetString("ResourceUriNotResourceDictionary", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The total duration of a binding update stepping sequence cannot be negative. That just doesn&apos;t make sense!.
        /// </summary>
        internal static string SteppingDurationCannotBeNegative {
            get {
                return ResourceManager.GetString("SteppingDurationCannotBeNegative", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided handle does not belong to a window created by WPF..
        /// </summary>
        internal static string WindowNotPresentation {
            get {
                return ResourceManager.GetString("WindowNotPresentation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type of object found at the root of the XAML&apos;s corresponding object tree does not match the specified generic type parameter..
        /// </summary>
        internal static string WrongXamlRootType {
            get {
                return ResourceManager.GetString("WrongXamlRootType", resourceCulture);
            }
        }
    }
}
