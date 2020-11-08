#include <string>

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
    // Ide szerintem még kéne más is.
    // Szerintetek hogy kéne? Teamsen írjátok meg.
    byte pixel;
}