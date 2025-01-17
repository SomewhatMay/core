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

namespace BadEcho.Interop;

/// <summary>
/// Represents a callback that processes messages sent to a subclassed window.
/// </summary>
/// <param name="hWnd">A handle to the window.</param>
/// <param name="msg">The message.</param>
/// <param name="wParam">Additional message-specific information.</param>
/// <param name="lParam">Additional message-specific information.</param>
/// <param name="handled">A value that indicates whether the message was handled.</param>
/// <returns>
/// The result of the message processing, which of course depends on the message being processed.
/// </returns>
public delegate IntPtr WindowHookProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam, ref bool handled);