﻿using Azure;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Compute;

// 1. Azure Authorization
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

// 2. Get the ResourceGroup
string rgName = "myRG";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);

// 3. Get the virtual machine collection from the resource group
VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
string vmName = "myVM";
VirtualMachineResource vm = await vmCollection.GetAsync(vmName);

// 4. We delete the Virtual Machine
await vm.DeleteAsync(WaitUntil.Completed);
