# Makefile for Writing Make Files Example
# *****************************************************
# Variables to control Makefile operation
CXX	=	g++
CXXFLAGS	=	-Wall	-g
# ****************************************************
# Targets needed to bring the executable up to date
CiffCaffParser:	CiffCaffParser.o
	$(CXX)	$(CXXFLAGS)	-o	CiffCaffParser	CiffCaffParser.o
# The main.o target can be written more simply
CiffCaffParser.o:	CiffCaffParser.cpp
	$(CXX)	$(CXXFLAGS)	-c	CiffCaffParser.cpp