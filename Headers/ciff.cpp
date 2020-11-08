#include <string>
using namespace std;

struct Ciff {
	CiffHeader ciffHeader;
	CiffContent ciffContent;
};

struct CiffHeader
{
	char magic[4];
	int header_size;
	int content_size;
	int width;
	int height;
	string caption;
	string tags;
};

struct CiffContent
{
	int i, rows, cols;
	char** pixels;

	/* initialize in this way
	*
		pixels = malloc(rows * sizeof(int*));
		for (i = 0;i < rows;i++)
			mat[i] = malloc(cols * sizeof(int));
	*
	*/
};