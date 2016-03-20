﻿namespace RegistrySpy
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Globalization;
	using System.Management;

	// Functions ShouldSerialize<PropertyName> are functions used by VS property browser to check if a particular property has to be serialized. These functions are added for all ValueType properties ( properties of type Int32, BOOL etc.. which cannot be set to null). These functions use Is<PropertyName>Null function. These functions are also used in the TypeConverter implementation for the properties to check for NULL value of property so that an empty value can be shown in Property browser in case of Drag and Drop in Visual studio.
	// Functions Is<PropertyName>Null() are used to check if a property is NULL.
	// Functions Reset<PropertyName> are added for Nullable Read/Write properties. These functions are used by VS designer in property browser to set a property to NULL.
	// Every property added to the class for WMI property has attributes set to define its behavior in Visual Studio designer and also to define a TypeConverter to be used.
	// An Early Bound class generated for the WMI class.RegistryTreeChangeEvent
	public class RegistryTreeChangeEvent : System.ComponentModel.Component
	{
		#region Static Fields

		// Private property to hold the WMI namespace in which the class resides.
		private static string CreatedWmiNamespace = "root\\DEFAULT";

		// Private property to hold the name of WMI class which created this class.
		private static string CreatedClassName = "RegistryTreeChangeEvent";

		// Private member variable to hold the ManagementScope which is used by the various methods.
		private static System.Management.ManagementScope statMgmtScope = null;

		#endregion Static Fields

		#region Fields

		// Member variable to store the 'automatic commit' behavior for the class.
		private bool AutoCommitProp;

		// Underlying lateBound WMI object.
		private System.Management.ManagementObject PrivateLateBoundObject;
		private ManagementSystemProperties PrivateSystemProperties;

		// The current WMI object used
		private System.Management.ManagementBaseObject curObj;

		// Private variable to hold the embedded property representing the instance.
		private System.Management.ManagementBaseObject embeddedObj;

		// Flag to indicate if the instance is an embedded object.
		private bool isEmbedded;

		#endregion Fields

		#region Constructors

		// Below are different overloads of constructors to initialize an instance of the class with a WMI object.
		public RegistryTreeChangeEvent()
		{
			this.InitializeObject(null, null, null);
		}

		public RegistryTreeChangeEvent(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions)
		{
			this.InitializeObject(null, path, getOptions);
		}

		public RegistryTreeChangeEvent(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path)
		{
			this.InitializeObject(mgmtScope, path, null);
		}

		public RegistryTreeChangeEvent(System.Management.ManagementPath path)
		{
			this.InitializeObject(null, path, null);
		}

		public RegistryTreeChangeEvent(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions)
		{
			this.InitializeObject(mgmtScope, path, getOptions);
		}

		public RegistryTreeChangeEvent(System.Management.ManagementObject theObject)
		{
			Initialize();
			if ((CheckIfProperClass(theObject) == true)) {
			    PrivateLateBoundObject = theObject;
			    PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
			    curObj = PrivateLateBoundObject;
			}
			else {
			    throw new System.ArgumentException("Class name does not match.");
			}
		}

		public RegistryTreeChangeEvent(System.Management.ManagementBaseObject theObject)
		{
			Initialize();
			if ((CheckIfProperClass(theObject) == true)) {
			    embeddedObj = theObject;
			    PrivateSystemProperties = new ManagementSystemProperties(theObject);
			    curObj = embeddedObj;
			    isEmbedded = true;
			}
			else {
			    throw new System.ArgumentException("Class name does not match.");
			}
		}

		#endregion Constructors

		#region Public Properties

		// Property to show the commit behavior for the WMI object. If true, WMI object will be automatically saved after each property modification.(ie. Put() is called after modification of a property).
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AutoCommit
		{
			get {
			    return AutoCommitProp;
			}
			set {
			    AutoCommitProp = value;
			}
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string Hive
		{
			get {
			    return ((string)(curObj["Hive"]));
			}
			set {
			    curObj["Hive"] = value;
			    if (((isEmbedded == false) 
			                && (AutoCommitProp == true))) {
			        PrivateLateBoundObject.Put();
			    }
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsTIME_CREATEDNull
		{
			get {
			    if ((curObj["TIME_CREATED"] == null)) {
			        return true;
			    }
			    else {
			        return false;
			    }
			}
		}

		// Property returning the underlying lateBound object.
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public System.Management.ManagementBaseObject LateBoundObject
		{
			get {
			    return curObj;
			}
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string ManagementClassName
		{
			get {
			    string strRet = CreatedClassName;
			    if ((curObj != null)) {
			        if ((curObj.ClassPath != null)) {
			            strRet = ((string)(curObj["__CLASS"]));
			            if (((strRet == null) 
			                        || (strRet == string.Empty))) {
			                strRet = CreatedClassName;
			            }
			        }
			    }
			    return strRet;
			}
		}

		// Property returns the namespace of the WMI class.
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string OriginatingNamespace
		{
			get {
			    return "root\\DEFAULT";
			}
		}

		// The ManagementPath of the underlying WMI object.
		[Browsable(true)]
		public System.Management.ManagementPath Path
		{
			get {
			    if ((isEmbedded == false)) {
			        return PrivateLateBoundObject.Path;
			    }
			    else {
			        return null;
			    }
			}
			set {
			    if ((isEmbedded == false)) {
			        if ((CheckIfProperClass(null, value, null) != true)) {
			            throw new System.ArgumentException("Class name does not match.");
			        }
			        PrivateLateBoundObject.Path = value;
			    }
			}
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string RootPath
		{
			get {
			    return ((string)(curObj["RootPath"]));
			}
			set {
			    curObj["RootPath"] = value;
			    if (((isEmbedded == false) 
			                && (AutoCommitProp == true))) {
			        PrivateLateBoundObject.Put();
			    }
			}
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public byte[] SECURITY_DESCRIPTOR
		{
			get {
			    return ((byte[])(curObj["SECURITY_DESCRIPTOR"]));
			}
			set {
			    curObj["SECURITY_DESCRIPTOR"] = value;
			    if (((isEmbedded == false) 
			                && (AutoCommitProp == true))) {
			        PrivateLateBoundObject.Put();
			    }
			}
		}

		// ManagementScope of the object.
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public System.Management.ManagementScope Scope
		{
			get {
			    if ((isEmbedded == false)) {
			        return PrivateLateBoundObject.Scope;
			    }
			    else {
			        return null;
			    }
			}
			set {
			    if ((isEmbedded == false)) {
			        PrivateLateBoundObject.Scope = value;
			    }
			}
		}

		// Public static scope property which is used by the various methods.
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static System.Management.ManagementScope StaticScope
		{
			get {
			    return statMgmtScope;
			}
			set {
			    statMgmtScope = value;
			}
		}

		// Property pointing to an embedded object to get System properties of the WMI object.
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ManagementSystemProperties SystemProperties
		{
			get {
			    return PrivateSystemProperties;
			}
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[TypeConverter(typeof(WMIValueTypeConverter))]
		public ulong TIME_CREATED
		{
			get {
			    if ((curObj["TIME_CREATED"] == null)) {
			        return System.Convert.ToUInt64(0);
			    }
			    return ((ulong)(curObj["TIME_CREATED"]));
			}
			set {
			    curObj["TIME_CREATED"] = value;
			    if (((isEmbedded == false) 
			                && (AutoCommitProp == true))) {
			        PrivateLateBoundObject.Put();
			    }
			}
		}

		#endregion Public Properties

		#region Private Methods

		private bool CheckIfProperClass(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions OptionsParam)
		{
			if (((path != null) 
			            && (string.Compare(path.ClassName, this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
			    return true;
			}
			else {
			    return CheckIfProperClass(new System.Management.ManagementObject(mgmtScope, path, OptionsParam));
			}
		}

		private bool CheckIfProperClass(System.Management.ManagementBaseObject theObj)
		{
			if (((theObj != null) 
			            && (string.Compare(((string)(theObj["__CLASS"])), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
			    return true;
			}
			else {
			    System.Array parentClasses = ((System.Array)(theObj["__DERIVATION"]));
			    if ((parentClasses != null)) {
			        int count = 0;
			        for (count = 0; (count < parentClasses.Length); count = (count + 1)) {
			            if ((string.Compare(((string)(parentClasses.GetValue(count))), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0)) {
			                return true;
			            }
			        }
			    }
			}
			return false;
		}

		private static string ConstructPath()
		{
			string strPath = "root\\DEFAULT:RegistryTreeChangeEvent";
			return strPath;
		}

		private void Initialize()
		{
			AutoCommitProp = true;
			isEmbedded = false;
		}

		private void InitializeObject(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions)
		{
			Initialize();
			if ((path != null)) {
			    if ((CheckIfProperClass(mgmtScope, path, getOptions) != true)) {
			        throw new System.ArgumentException("Class name does not match.");
			    }
			}
			PrivateLateBoundObject = new System.Management.ManagementObject(mgmtScope, path, getOptions);
			PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
			curObj = PrivateLateBoundObject;
		}

		private void ResetHive()
		{
			curObj["Hive"] = null;
			if (((isEmbedded == false) 
			            && (AutoCommitProp == true))) {
			    PrivateLateBoundObject.Put();
			}
		}

		private void ResetRootPath()
		{
			curObj["RootPath"] = null;
			if (((isEmbedded == false) 
			            && (AutoCommitProp == true))) {
			    PrivateLateBoundObject.Put();
			}
		}

		private void ResetSECURITY_DESCRIPTOR()
		{
			curObj["SECURITY_DESCRIPTOR"] = null;
			if (((isEmbedded == false) 
			            && (AutoCommitProp == true))) {
			    PrivateLateBoundObject.Put();
			}
		}

		private void ResetTIME_CREATED()
		{
			curObj["TIME_CREATED"] = null;
			if (((isEmbedded == false) 
			            && (AutoCommitProp == true))) {
			    PrivateLateBoundObject.Put();
			}
		}

		private bool ShouldSerializeTIME_CREATED()
		{
			if ((this.IsTIME_CREATEDNull == false)) {
			    return true;
			}
			return false;
		}

		#endregion Private Methods

		#region Public Methods

		[Browsable(true)]
		public void CommitObject()
		{
			if ((isEmbedded == false)) {
			    PrivateLateBoundObject.Put();
			}
		}

		[Browsable(true)]
		public void CommitObject(System.Management.PutOptions putOptions)
		{
			if ((isEmbedded == false)) {
			    PrivateLateBoundObject.Put(putOptions);
			}
		}

		[Browsable(true)]
		public static RegistryTreeChangeEvent CreateInstance()
		{
			System.Management.ManagementScope mgmtScope = null;
			if ((statMgmtScope == null)) {
			    mgmtScope = new System.Management.ManagementScope();
			    mgmtScope.Path.NamespacePath = CreatedWmiNamespace;
			}
			else {
			    mgmtScope = statMgmtScope;
			}
			System.Management.ManagementPath mgmtPath = new System.Management.ManagementPath(CreatedClassName);
			System.Management.ManagementClass tmpMgmtClass = new System.Management.ManagementClass(mgmtScope, mgmtPath, null);
			return new RegistryTreeChangeEvent(tmpMgmtClass.CreateInstance());
		}

		[Browsable(true)]
		public void Delete()
		{
			PrivateLateBoundObject.Delete();
		}

		// Different overloads of GetInstances() help in enumerating instances of the WMI class.
		public static RegistryTreeChangeEventCollection GetInstances()
		{
			return GetInstances(null, null, null);
		}

		public static RegistryTreeChangeEventCollection GetInstances(string condition)
		{
			return GetInstances(null, condition, null);
		}

		public static RegistryTreeChangeEventCollection GetInstances(System.String [] selectedProperties)
		{
			return GetInstances(null, null, selectedProperties);
		}

		public static RegistryTreeChangeEventCollection GetInstances(string condition, System.String [] selectedProperties)
		{
			return GetInstances(null, condition, selectedProperties);
		}

		public static RegistryTreeChangeEventCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions)
		{
			if ((mgmtScope == null)) {
			    if ((statMgmtScope == null)) {
			        mgmtScope = new System.Management.ManagementScope();
			        mgmtScope.Path.NamespacePath = "root\\DEFAULT";
			    }
			    else {
			        mgmtScope = statMgmtScope;
			    }
			}
			System.Management.ManagementPath pathObj = new System.Management.ManagementPath();
			pathObj.ClassName = "RegistryTreeChangeEvent";
			pathObj.NamespacePath = "root\\DEFAULT";
			System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
			if ((enumOptions == null)) {
			    enumOptions = new System.Management.EnumerationOptions();
			    enumOptions.EnsureLocatable = true;
			}
			return new RegistryTreeChangeEventCollection(clsObject.GetInstances(enumOptions));
		}

		public static RegistryTreeChangeEventCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition)
		{
			return GetInstances(mgmtScope, condition, null);
		}

		public static RegistryTreeChangeEventCollection GetInstances(System.Management.ManagementScope mgmtScope, System.String [] selectedProperties)
		{
			return GetInstances(mgmtScope, null, selectedProperties);
		}

		public static RegistryTreeChangeEventCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, System.String [] selectedProperties)
		{
			if ((mgmtScope == null)) {
			    if ((statMgmtScope == null)) {
			        mgmtScope = new System.Management.ManagementScope();
			        mgmtScope.Path.NamespacePath = "root\\DEFAULT";
			    }
			    else {
			        mgmtScope = statMgmtScope;
			    }
			}
			System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("RegistryTreeChangeEvent", condition, selectedProperties));
			System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
			enumOptions.EnsureLocatable = true;
			ObjectSearcher.Options = enumOptions;
			return new RegistryTreeChangeEventCollection(ObjectSearcher.Get());
		}

		#endregion Public Methods

		#region Other

		// Embedded class to represent WMI system Properties.
		[TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
		public class ManagementSystemProperties
		{
			#region Fields

			private System.Management.ManagementBaseObject PrivateLateBoundObject;

			#endregion Fields

			#region Constructors

			public ManagementSystemProperties(System.Management.ManagementBaseObject ManagedObject)
			{
				PrivateLateBoundObject = ManagedObject;
			}

			#endregion Constructors

			#region Public Properties

			[Browsable(true)]
			public string CLASS
			{
				get {
				    return ((string)(PrivateLateBoundObject["__CLASS"]));
				}
			}

			[Browsable(true)]
			public string[] DERIVATION
			{
				get {
				    return ((string[])(PrivateLateBoundObject["__DERIVATION"]));
				}
			}

			[Browsable(true)]
			public string DYNASTY
			{
				get {
				    return ((string)(PrivateLateBoundObject["__DYNASTY"]));
				}
			}

			[Browsable(true)]
			public int GENUS
			{
				get {
				    return ((int)(PrivateLateBoundObject["__GENUS"]));
				}
			}

			[Browsable(true)]
			public string NAMESPACE
			{
				get {
				    return ((string)(PrivateLateBoundObject["__NAMESPACE"]));
				}
			}

			[Browsable(true)]
			public string PATH
			{
				get {
				    return ((string)(PrivateLateBoundObject["__PATH"]));
				}
			}

			[Browsable(true)]
			public int PROPERTY_COUNT
			{
				get {
				    return ((int)(PrivateLateBoundObject["__PROPERTY_COUNT"]));
				}
			}

			[Browsable(true)]
			public string RELPATH
			{
				get {
				    return ((string)(PrivateLateBoundObject["__RELPATH"]));
				}
			}

			[Browsable(true)]
			public string SERVER
			{
				get {
				    return ((string)(PrivateLateBoundObject["__SERVER"]));
				}
			}

			[Browsable(true)]
			public string SUPERCLASS
			{
				get {
				    return ((string)(PrivateLateBoundObject["__SUPERCLASS"]));
				}
			}

			#endregion Public Properties
		}

		// Enumerator implementation for enumerating instances of the class.
		public class RegistryTreeChangeEventCollection : object, ICollection
		{
			#region Fields

			private ManagementObjectCollection privColObj;

			#endregion Fields

			#region Constructors

			public RegistryTreeChangeEventCollection(ManagementObjectCollection objCollection)
			{
				privColObj = objCollection;
			}

			#endregion Constructors

			#region Public Properties

			public virtual int Count
			{
				get {
				    return privColObj.Count;
				}
			}

			public virtual bool IsSynchronized
			{
				get {
				    return privColObj.IsSynchronized;
				}
			}

			public virtual object SyncRoot
			{
				get {
				    return this;
				}
			}

			#endregion Public Properties

			#region Public Methods

			public virtual void CopyTo(System.Array array, int index)
			{
				privColObj.CopyTo(array, index);
				int nCtr;
				for (nCtr = 0; (nCtr < array.Length); nCtr = (nCtr + 1)) {
				    array.SetValue(new RegistryTreeChangeEvent(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
				}
			}

			public virtual System.Collections.IEnumerator GetEnumerator()
			{
				return new RegistryTreeChangeEventEnumerator(privColObj.GetEnumerator());
			}

			#endregion Public Methods

			#region Other

			public class RegistryTreeChangeEventEnumerator : object, System.Collections.IEnumerator
			{
				#region Fields

				private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;

				#endregion Fields

				#region Constructors

				public RegistryTreeChangeEventEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum)
				{
					privObjEnum = objEnum;
				}

				#endregion Constructors

				#region Public Properties

				public virtual object Current
				{
					get {
					    return new RegistryTreeChangeEvent(((System.Management.ManagementObject)(privObjEnum.Current)));
					}
				}

				#endregion Public Properties

				#region Public Methods

				public virtual bool MoveNext()
				{
					return privObjEnum.MoveNext();
				}

				public virtual void Reset()
				{
					privObjEnum.Reset();
				}

				#endregion Public Methods
			}

			#endregion Other
		}

		// TypeConverter to handle null values for ValueType properties
		public class WMIValueTypeConverter : TypeConverter
		{
			#region Fields

			private TypeConverter baseConverter;
			private System.Type baseType;

			#endregion Fields

			#region Constructors

			public WMIValueTypeConverter(System.Type inBaseType)
			{
				baseConverter = TypeDescriptor.GetConverter(inBaseType);
				baseType = inBaseType;
			}

			#endregion Constructors

			#region Public Methods

			public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type srcType)
			{
				return baseConverter.CanConvertFrom(context, srcType);
			}

			public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType)
			{
				return baseConverter.CanConvertTo(context, destinationType);
			}

			public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
			{
				return baseConverter.ConvertFrom(context, culture, value);
			}

			public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
			{
				if ((baseType.BaseType == typeof(System.Enum))) {
				    if ((value.GetType() == destinationType)) {
				        return value;
				    }
				    if ((((value == null) 
				                && (context != null)) 
				                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
				        return  "NULL_ENUM_VALUE" ;
				    }
				    return baseConverter.ConvertTo(context, culture, value, destinationType);
				}
				if (((baseType == typeof(bool)) 
				            && (baseType.BaseType == typeof(System.ValueType)))) {
				    if ((((value == null) 
				                && (context != null)) 
				                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
				        return "";
				    }
				    return baseConverter.ConvertTo(context, culture, value, destinationType);
				}
				if (((context != null) 
				            && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
				    return "";
				}
				return baseConverter.ConvertTo(context, culture, value, destinationType);
			}

			public override object CreateInstance(System.ComponentModel.ITypeDescriptorContext context, System.Collections.IDictionary dictionary)
			{
				return baseConverter.CreateInstance(context, dictionary);
			}

			public override bool GetCreateInstanceSupported(System.ComponentModel.ITypeDescriptorContext context)
			{
				return baseConverter.GetCreateInstanceSupported(context);
			}

			public override PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributeVar)
			{
				return baseConverter.GetProperties(context, value, attributeVar);
			}

			public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context)
			{
				return baseConverter.GetPropertiesSupported(context);
			}

			public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
			{
				return baseConverter.GetStandardValues(context);
			}

			public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context)
			{
				return baseConverter.GetStandardValuesExclusive(context);
			}

			public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
			{
				return baseConverter.GetStandardValuesSupported(context);
			}

			#endregion Public Methods
		}

		#endregion Other
	}
}