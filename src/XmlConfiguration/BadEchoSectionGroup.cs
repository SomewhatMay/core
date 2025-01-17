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

namespace BadEcho.XmlConfiguration;

/// <summary>
/// Provides a configuration section group for all Bad Echo related configuration sections.
/// </summary>
/// <suppresions>
/// ReSharper disable ConstantNullCoalescingCondition
/// </suppresions>
internal sealed class BadEchoSectionGroup : ConfigurationSectionGroup
{
    /// <summary>
    /// Gets the schema name for Bad Echo's configuration section group.
    /// </summary>
    public static string Schema
        => "badEcho";

    /// <summary>
    /// Gets an instance of this section group from the provided configuration.
    /// </summary>
    /// <param name="configuration">A configuration file in which this section group is declared.</param>
    /// <returns>This section group as it is declared in <c>configuration</c>.</returns>
    public static BadEchoSectionGroup GetSectionGroup(System.Configuration.Configuration configuration)
    {
        Require.NotNull(configuration, nameof(configuration));

        return (BadEchoSectionGroup) configuration.GetSectionGroup(Schema) ?? new BadEchoSectionGroup();
    }

    /// <summary>
    /// Gets an instance of this section group from the current application's default configuration.
    /// </summary>
    /// <returns>This section group as it is declared in the current application's default configuration.</returns>
    internal static BadEchoSectionGroup GetSectionGroup()
    {
        System.Configuration.Configuration currentConfiguration
            = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        return (BadEchoSectionGroup) currentConfiguration.GetSectionGroup(Schema) ?? new BadEchoSectionGroup();
    }
}