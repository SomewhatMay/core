using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if RELEASE
using BadEcho.Properties;

[assembly: InternalsVisibleTo("BadEcho.Game.Tests,PublicKey="+BuildInfo.PublicKey)]
#else
[assembly: InternalsVisibleTo("BadEcho.Game.Tests")]
#endif

[assembly: ComVisible(false)]
[assembly: Guid("76aa12cf-f354-4e26-a74f-6a20380548fc")]

[assembly: SuppressMessage("Naming",
                           "CA1720:Identifier contains type name",
                           Scope = "type",
                           Target = "~T:BadEcho.Game.Pipeline.Tiles.CustomPropertyType",
                           Justification = "This rule generates noise for enum types. The purpose of this enum is to specify a custom property's type, therefore its members are appropriately named after types. The .NET runtime itself violates this rule many times for similarly purposed enum types.")]