using Authenticator.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Authenticator.Messages;

public class AddAccountMessage : AsyncRequestMessage<AddAccountWindowViewModel?>;
