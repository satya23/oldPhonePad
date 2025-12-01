# Quick Installation Guide

## Installing .NET SDK on macOS

Since you're on macOS, here are the easiest ways to install .NET SDK:

### Option 1: Using Homebrew (Recommended)

If you have Homebrew installed:

```bash
brew install --cask dotnet-sdk
```

### Option 2: Direct Download

1. Visit: https://dotnet.microsoft.com/download/dotnet/8.0
2. Download the macOS installer (.pkg file)
3. Run the installer
4. Follow the installation wizard

### Option 3: Using the Install Script

```bash
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 8.0
```

Then add to your PATH (add to `~/.zshrc` or `~/.bash_profile`):

```bash
export DOTNET_ROOT=$HOME/.dotnet
export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
```

## Verify Installation

After installation, verify it works:

```bash
dotnet --version
```

You should see something like: `8.0.xxx`

## Build and Test

Once .NET is installed, you can build and test:

```bash
cd /Users/satyabratarout/agent/projects/oldPhonePad
dotnet build OldPhonePad.sln
dotnet test OldPhonePad.sln
dotnet run --project OldPhonePad.csproj
```

## Troubleshooting

If `dotnet` command is still not found after installation:

1. **Restart your terminal** - PATH changes require a new terminal session
2. **Check your PATH**: `echo $PATH` should include dotnet
3. **For Homebrew**: Make sure `/opt/homebrew/bin` is in your PATH
4. **Manual PATH**: Add `/usr/local/share/dotnet` to your PATH if installed via direct download

