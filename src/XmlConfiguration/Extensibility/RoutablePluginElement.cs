﻿//-----------------------------------------------------------------------
// <copyright>
//		Created by Matt Weber <matt@badecho.com>
//		Copyright @ 2023 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under the
//		GNU Affero General Public License v3.0.
//
//		See accompanying file LICENSE.md or a copy at:
//		https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using System.Configuration;
using BadEcho.Extensibility.Configuration;

namespace BadEcho.XmlConfiguration.Extensibility;

/// <summary>
/// Provides a configuration element for a call-routable plugin.
/// </summary>
internal sealed class RoutablePluginElement : GuidConfigurationElement, IRoutablePluginConfiguration
{
    private const string METHOD_CLAIMS_CHILD_SCHEMA = "methodClaims";
    private const string PRIMARY_ATTRIBUTE_SCHEMA = "primary";

    private static readonly Lazy<ConfigurationPropertyCollection> _Properties
        = new(InitializeProperties, LazyThreadSafetyMode.PublicationOnly);

    IEnumerable<string> IRoutablePluginConfiguration.MethodClaims
        => MethodClaims.Select(m => m.Name);

    /// <summary>
    /// Gets the collection of methods claimed by the plugin represented by this element.
    /// </summary>
    public NamedElementCollection<MethodClaimElement> MethodClaims
        => (NamedElementCollection<MethodClaimElement>) base[METHOD_CLAIMS_CHILD_SCHEMA];

    /// <summary>
    /// Gets a value indicating whether the plugin represented by this element is the primary call-routable plugin
    /// for a particular contract.
    /// </summary>
    public bool Primary
        => (bool) base[PRIMARY_ATTRIBUTE_SCHEMA];

    /// <summary>
    /// Gets the schema name for the attribute indicating whether the plugin represented by this element is the primary
    /// call-routable plugin for a particular contract.
    /// </summary>
    internal static string PrimaryAttributeSchema
        => "primary";

    /// <inheritdoc/>
    protected override ConfigurationPropertyCollection Properties
        => _Properties.Value;

    private static ConfigurationPropertyCollection InitializeProperties()
        => new()
           {
               new ConfigurationProperty(METHOD_CLAIMS_CHILD_SCHEMA,
                                         typeof(NamedElementCollection<MethodClaimElement>),
                                         null,
                                         null,
                                         null,
                                         ConfigurationPropertyOptions.None),
               new ConfigurationProperty(PRIMARY_ATTRIBUTE_SCHEMA,
                                         typeof(bool),
                                         false,
                                         null,
                                         null,
                                         ConfigurationPropertyOptions.None),
               CreateIdProperty(),
               CreateNameProperty()
           };
}