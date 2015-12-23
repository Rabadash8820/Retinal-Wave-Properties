namespace MeaData {

    // This class is used by the Fody Virtuosity package
    // It stops the package from adding 'virtual' to all the properties in a marked class.
    // No reference assembly is shipped with Virtuosity so this had to be added manually.
    [DoNotVirtualize]   // Don't virtualize this either!  (not really necessary while there are no members)
    internal class DoNotVirtualizeAttribute : System.Attribute { }

}
