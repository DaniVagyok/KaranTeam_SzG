==15970== Memcheck, a memory error detector
==15970== Copyright (C) 2002-2017, and GNU GPL'd, by Julian Seward et al.
==15970== Using Valgrind-3.13.0 and LibVEX; rerun with -h for copyright info
==15970== Command: ./CiffCaffParser
==15970== 
==15970== Syscall param openat(filename) points to unaddressable byte(s)
==15970==    at 0x54ECD9E: open (open64.c:47)
==15970==    by 0x54695F9: _IO_file_open (fileops.c:189)
==15970==    by 0x54695F9: _IO_file_fopen@@GLIBC_2.2.5 (fileops.c:281)
==15970==    by 0x545BF19: __fopen_internal (iofopen.c:78)
==15970==    by 0x545BF19: fopen@@GLIBC_2.2.5 (iofopen.c:89)
==15970==    by 0x4EEFE4F: std::__basic_file<char>::open(char const*, std::_Ios_Openmode, int) (in /usr/lib/x86_64-linux-gnu/libstdc++.so.6.0.25)
==15970==    by 0x4F300D9: std::basic_filebuf<char, std::char_traits<char> >::open(char const*, std::_Ios_Openmode) (in /usr/lib/x86_64-linux-gnu/libstdc++.so.6.0.25)
==15970==    by 0x4F302AF: std::basic_ifstream<char, std::char_traits<char> >::open(char const*, std::_Ios_Openmode) (in /usr/lib/x86_64-linux-gnu/libstdc++.so.6.0.25)
==15970==    by 0x10977F: main (CiffCaffParser.cpp:142)
==15970==  Address 0x0 is not stack'd, malloc'd or (recently) free'd
==15970== 
==15970== Conditional jump or move depends on uninitialised value(s)
==15970==    at 0x109842: main (CiffCaffParser.cpp:152)
==15970== 
==15970== Conditional jump or move depends on uninitialised value(s)
==15970==    at 0x109891: main (CiffCaffParser.cpp:157)
==15970== 
==15970== Conditional jump or move depends on uninitialised value(s)
==15970==    at 0x1099C0: main (CiffCaffParser.cpp:170)
==15970== 
==15970== 
==15970== HEAP SUMMARY:
==15970==     in use at exit: 0 bytes in 0 blocks
==15970==   total heap usage: 2 allocs, 2 frees, 73,256 bytes allocated
==15970== 
==15970== All heap blocks were freed -- no leaks are possible
==15970== 
==15970== For counts of detected and suppressed errors, rerun with: -v
==15970== Use --track-origins=yes to see where uninitialised values come from
