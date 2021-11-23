﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2021 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		Creative Commons Attribution-NonCommercial 4.0 International License.
//
//		See accompanying file LICENSE.md or a copy at:
//		http://creativecommons.org/licenses/by-nc/4.0/
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using BadEcho.Fenestra.ViewModels;
using BadEcho.Odin;
using BadEcho.Odin.Extensions;
using BadEcho.Odin.Logging;
using BadEcho.Omnified.Vision.Extensibility.Properties;

namespace BadEcho.Omnified.Vision.Extensibility
{
    /// <summary>
    /// Provides a base snap-in module granting Vision to Omnified data.
    /// </summary>
    public abstract class VisionModule<TModel, TViewModel> : IVisionModule
        where TViewModel : class, IViewModel<TModel>, new()
    {
        private readonly AnchorPointLocation? _configuredLocation;
        private readonly int _maximumMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisionModule{TModel, TViewModel}"/> class.
        /// </summary>
        /// <param name="configuration">Configuration settings for the Vision application.</param>
        protected VisionModule(IVisionConfiguration configuration)
        {
            Require.NotNull(configuration, nameof(configuration));
            
            var moduleConfiguration 
                = configuration.Modules.GetConfiguration<VisionModuleConfiguration>(ModuleName);

            _configuredLocation = moduleConfiguration.Location;
            _maximumMessages = moduleConfiguration.MaxMessages;
        }

        /// <inheritdoc/>
        public AnchorPointLocation Location
            => _configuredLocation ?? DefaultLocation;
        
        /// <inheritdoc/>
        public virtual GrowthDirection GrowthDirection
            => GrowthDirection.Vertical;

        /// <inheritdoc/>
        public virtual bool ProcessNewMessagesOnly
            => false;

        /// <inheritdoc/>
        public abstract string MessageFile
        { get; }

        /// <summary>
        /// Gets the name that identifies the module in a configuration context.
        /// </summary>
        protected string ModuleName
            => GetType().Assembly.GetName().Name ?? string.Empty;

        /// <summary>
        /// Gets the module's root view model instance.
        /// </summary>
        protected TViewModel ViewModel
        { get; } = new();

        /// <summary>
        /// Gets the default location of the module's anchor point.
        /// </summary>
        protected abstract AnchorPointLocation DefaultLocation
        { get; }

        /// <inheritdoc/>
        public IViewModel EnableModule(IMessageFileProvider messageProvider)
        {
            Require.NotNull(messageProvider, nameof(messageProvider));

            if (!string.IsNullOrEmpty(messageProvider.CurrentMessages))
                ViewModel.Bind(ReadMessages(messageProvider.CurrentMessages));

            messageProvider.NewMessages += HandleNewMessages;

            return ViewModel;
        }

        /// <summary>
        /// Parses bindable <typeparamref name="TModel"/> objects from the provided contents of a message file.
        /// </summary>
        /// <param name="messages">The contents of a message file to parse.</param>
        /// <returns>A sequence of <typeparamref name="TModel"/> objects parsed from <c>messages</c>.</returns>
        protected abstract IEnumerable<TModel>? ParseMessages(string messages);

        private IEnumerable<TModel> ReadMessages(string messages)
        {
            try
            {
                IEnumerable<TModel> parsedMessages = ParseMessages(messages)
                    ?? throw new ArgumentException(Strings.NullMessageValue, nameof(messages));

                return _maximumMessages > 0 ? parsedMessages.TakeLast(_maximumMessages) : parsedMessages;
            }
            catch (JsonException jsonEx)
            {
                Logger.Error(Strings.ReadMessagesFailure.InvariantFormat(messages), jsonEx);

                return Enumerable.Empty<TModel>();
            }
        }

        private void HandleNewMessages(object? sender, EventArgs<string> e)
        {
            var models = ReadMessages(e.Data);

            ViewModel.Bind(models);
        }
    }
}