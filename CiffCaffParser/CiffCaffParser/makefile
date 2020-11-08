CXX = g++
CXXFLAGS = -Wall -g
EXECUTABLE  := CiffCaffParser

$(EXECUTABLE): $(EXECUTABLE).o
	@echo "🚧 Building..."
	$(CXX) $(CXXFLAGS) -o $(EXECUTABLE) $(EXECUTABLE).o

$(EXECUTABLE).o: $(EXECUTABLE).cpp
	$(CXX) $(CXXFLAGS) -c $(EXECUTABLE).cpp

clean:
	@echo "🧹 Clearing..."
	-rm $(EXECUTABLE)
	-rm $(EXECUTABLE).o
