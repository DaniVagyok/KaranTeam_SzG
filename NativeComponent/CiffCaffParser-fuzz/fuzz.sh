#!/bin/bash
# Build and run the instrumented executable

# AFL installation path, modify as required
AFL=~/NativeComponent/CiffCaffParser-fuzz/AFL

# Use AFL as a compile front-end
export CC=$AFL/afl-clang
export CXX=$AFL/afl-clang++

SL=/System/Library; PL=com.apple.ReportCrash
launchctl unload -w ${SL}/LaunchAgents/${PL}.plist
sudo launchctl unload -w ${SL}/LaunchDaemons/${PL}.Root.plist

echo core | sudo tee -a /proc/sys/kernel/core_pattern

# Build the instrumented executable and run it under AFL
mkdir -p aflbuild \
&& cd aflbuild \
&& cmake .. \
&& make \
&& $AFL/afl-fuzz -i ../testcases -o ../findings ./CiffCaffParser @@
