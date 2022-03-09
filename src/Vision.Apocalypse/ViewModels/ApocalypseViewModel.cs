﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2022 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under the
//		GNU Affero General Public License v3.0.
//
//		See accompanying file LICENSE.md or a copy at:
//		https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using BadEcho.Presentation.Messaging;
using BadEcho.Presentation.ViewModels;
using BadEcho.Collections;
using BadEcho.Vision.Extensibility;

namespace BadEcho.Vision.Apocalypse.ViewModels;

/// <summary>
/// Provides a view model that displays events generated by the Apocalypse system in an Omnified game.
/// </summary>
internal sealed class ApocalypseViewModel : PolymorphicCollectionViewModel<ApocalypseEvent, IApocalypseEventViewModel>
{
    private readonly double _effectMessageMaxWidth;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApocalypseViewModel"/> class.
    /// </summary>
    public ApocalypseViewModel()
        : this(new ApocalypseModuleConfiguration())
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApocalypseViewModel"/> class.
    /// </summary>
    /// <param name="configuration">The Apocalypse module configuration to apply to this view model.</param>
    /// <remarks>
    /// <para>
    /// The maximum number of messages in the module's configuration controls how many events are shown on the overlay during the
    /// periods of time when no new events are coming in. When a burst of new events do happen to be coming in, we allow for this
    /// capacity to be exceeded for a brief time, in order to lessen the chance that events occur and are never seen.
    /// </para>
    /// <para>
    /// Eventually, the collection of events gets trimmed down to its normal capacity. This is after a brief delay to, again,
    /// allow for at least a chance of them being seen. If the number of events in excess is ever so much, however, that it exceeds
    /// an amount that is double the number of allowed events, then an immediate trimming occurs (otherwise the entire screen might
    /// get filled up when we're experiencing a crazier-than-normal gameplay situation).
    /// </para>
    /// </remarks>
    public ApocalypseViewModel(ApocalypseModuleConfiguration configuration)
        : base(new CollectionViewModelOptions
               {
                   AsyncBatchBindings = true,
                   Capacity = configuration.MaxMessages,
                   CapacityEnforcementDelayLimit = configuration.MaxMessages * 2
               },
               new PresortedInsertionStrategy<IApocalypseEventViewModel, int>(vm => vm.Index, 
                                                                              OrderFromLocation(configuration)))
    {
        _effectMessageMaxWidth = configuration.EffectMessageMaxWidth;
        DirectionalCoefficient = CoefficientFromLocation(configuration);

        // Events from Player Apocalypse die rolls.
        RegisterDerivation<ExtraDamageEvent, PlayerApocalypseEventViewModel<ExtraDamageEvent>>();
        RegisterDerivation<TeleportitisEvent, PlayerApocalypseEventViewModel<TeleportitisEvent>>();
        RegisterDerivation<RiskOfMurderEvent, RiskOfMurderEventViewModel>();
        RegisterDerivation<OrgasmEvent, PlayerApocalypseEventViewModel<OrgasmEvent>>();

        // Fatalis events.
        RegisterDerivation<FatalisDeathEvent, ApocalypseEventViewModel<FatalisDeathEvent>>();
        RegisterDerivation<FatalisCuredEvent, ApocalypseEventViewModel<FatalisCuredEvent>>();

        // Events from Enemy Apocalypse die rolls.
        RegisterDerivation<EnemyApocalypseEvent, ApocalypseEventViewModel<EnemyApocalypseEvent>>();
    }

    /// <summary>
    /// Gets the mediator for messages to be sent or received through.
    /// </summary>
    public Mediator Mediator 
    { get; } = new();

    /// <summary>
    /// Gets a value that can be applied on quantities where directionality must be congruous with the location of the
    /// Apocalypse Vision module's anchor point.
    /// </summary>
    public double DirectionalCoefficient 
    { get; }

    /// <inheritdoc/>
    public override IApocalypseEventViewModel CreateChild(ApocalypseEvent model)
    {
        var viewModel = base.CreateChild(model);
            
        viewModel.EffectMessageMaxWidth = _effectMessageMaxWidth;

        return viewModel;
    }

    /// <inheritdoc/>
    protected override void OnChildrenChanged(CollectionPropertyChangedEventArgs e)
    {
        base.OnChildrenChanged(e);

        if (e.Action is CollectionPropertyChangedAction.Add)
            Mediator.Broadcast(SystemMessages.CancelAnimationsRequested);
    }

    private static bool OrderFromLocation(VisionModuleConfiguration configuration)
        => configuration.Location switch
        {
            AnchorPointLocation.TopLeft => false,
            AnchorPointLocation.TopCenter => false,
            AnchorPointLocation.TopRight => false,
            _ => true
        };

    private static double CoefficientFromLocation(VisionModuleConfiguration configuration)
        => configuration.Location switch
        {
            AnchorPointLocation.TopLeft => 1,
            AnchorPointLocation.TopCenter => 1,
            AnchorPointLocation.TopRight => 1,
            _ => -1
        };
}