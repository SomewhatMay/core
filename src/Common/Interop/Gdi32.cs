﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2023 Bad Echo LLC. All rights reserved.
//
//      Bad Echo Technologies are licensed under the
//      GNU Affero General Public License v3.0.
//
//      See accompanying file LICENSE.md or a copy at:
//      https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace BadEcho.Interop;

/// <summary>
/// Provides interoperability with the Graphics Device Interface functionality of Windows.
/// </summary>
internal static partial class Gdi32
{
    private const string LIBRARY_NAME = "gdi32";

    /// <summary>
    /// Gets the stock object type for a null brush.
    /// </summary>
    public static int StockObjectBrushNull = 5;

    /// <summary>
    /// Retrieves device-specific information for the specified device.
    /// </summary>
    /// <param name="hdc">A handle to the device context.</param>
    /// <param name="nIndex">An enumeration value that specifies the item to be returned.</param>
    /// <returns>The value for the requested information type.</returns>
    [LibraryImport(LIBRARY_NAME)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static partial int GetDeviceCaps(DeviceContextHandle hdc, DeviceInformation nIndex);

    /// <summary>
    /// Retrieves a handle to one of the stock pens, brushes, fonts, or palettes.
    /// </summary>
    /// <param name="stockObject">The type of stock object.</param>
    /// <returns>A handle to the requested logical object if successful; otherwise, null.</returns>
    [LibraryImport(LIBRARY_NAME, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static partial IntPtr GetStockObject(int stockObject);
}