#include <iostream>
#include <fstream>
#include <vector>
#include <stdio.h>

using namespace std;

/// <summary>
/// https://stackoverflow.com/a/30423762
/// </summary>
typedef struct                       /**** BMP file header structure ****/
{
    unsigned int   bfSize;           /* Size of file */
    unsigned short bfReserved1;      /* Reserved */
    unsigned short bfReserved2;      /* ... */
    unsigned int   bfOffBits;        /* Offset to bitmap data */
} BITMAPFILEHEADER;

typedef struct                       /**** BMP file info structure ****/
{
    unsigned int   biSize;           /* Size of info header */
    int            biWidth;          /* Width of image */
    int            biHeight;         /* Height of image */
    unsigned short biPlanes;         /* Number of color planes */
    unsigned short biBitCount;       /* Number of bits per pixel */
    unsigned int   biCompression;    /* Type of compression to use */
    unsigned int   biSizeImage;      /* Size of image data */
    int            biXPelsPerMeter;  /* X pixels per meter */
    int            biYPelsPerMeter;  /* Y pixels per meter */
    unsigned int   biClrUsed;        /* Number of colors used */
    unsigned int   biClrImportant;   /* Number of important colors */
} BITMAPINFOHEADER;

struct CiffHeader
{
    char magic[4];
    uint64_t header_size;
    uint64_t content_size;
    uint64_t width;
    uint64_t height;
    string caption;
    string tags;
};

struct CiffContent
{
    vector<unsigned int> pixels;
};

struct Ciff {
    CiffHeader ciffHeader;
    CiffContent ciffContent;
};

struct CaffBlock
{
    char id;
    uint64_t length;
    char* data;
};

struct CaffHeader
{
    char magic[4];
    uint64_t header_size;
    uint64_t num_anim;
};

struct CaffCredits
{
    char year[2];
    char month;
    char day;
    char hour;
    char minute;
    uint64_t creator_len;
    string creator;
};

struct CaffAnimation
{
    uint64_t duration;
    Ciff ciff;
};

void generateBMP(vector<unsigned int> rgbVector, int width, int height, string outputFileName) {
    BITMAPFILEHEADER bfh;
    BITMAPINFOHEADER bih;

    unsigned short bfType = 0x4d42;
    bfh.bfReserved1 = 0;
    bfh.bfReserved2 = 0;
    bfh.bfOffBits = 0x36;

    bih.biSize = sizeof(BITMAPINFOHEADER);
    bih.biPlanes = 1;
    bih.biBitCount = 24;
    bih.biCompression = 0;
    bih.biSizeImage = 0;
    bih.biXPelsPerMeter = 5000;
    bih.biYPelsPerMeter = 5000;
    bih.biClrUsed = 0;
    bih.biClrImportant = 0;


    bfh.bfSize = 2 + sizeof(BITMAPFILEHEADER) + sizeof(BITMAPINFOHEADER) + width * height * 3;
    bih.biWidth = width;
    bih.biHeight = height;

    FILE* file;
    string fileName = outputFileName + ".bmp";

    file = fopen(fileName.c_str(), "wb");
    if (!file)
    {
        printf("Could not write file\n");
        throw;
    }
    /*Write headers*/
    fwrite(&bfType, 1, sizeof(bfType), file);
    fwrite(&bfh, 1, sizeof(bfh), file);
    fwrite(&bih, 1, sizeof(bih), file);
    /*Write bitmap*/
    for (int i = (height * width * 3) - 1; i >= 0; i = i - 3) {
        unsigned int r = rgbVector[i];
        unsigned int g = rgbVector[i - 1];
        unsigned int b = rgbVector[i - 2];
        fwrite(&r, 1, 1, file);
        fwrite(&g, 1, 1, file);
        fwrite(&b, 1, 1, file);
    }
    fclose(file);
}


int main(int argc, char* argv[])
{
    string imageUrl;
    ifstream myfile;
    try
    {
        myfile.open(argv[1], ios::in | ios::binary); //Change file destination
        CaffBlock caffBlock;
        myfile.read((char*)&caffBlock.id, 1);
        myfile.read((char*)&caffBlock.length, 8);

        CaffHeader caffHeader;
        myfile.read((char*)&caffHeader.magic, 4);
        myfile.read((char*)&caffHeader.header_size, 8);
        myfile.read((char*)&caffHeader.num_anim, 8);

        for (int i = 0; i < caffHeader.num_anim + 1; i++)
        {
            CaffBlock innerCaffBlock;
            myfile.read((char*)&innerCaffBlock.id, sizeof(innerCaffBlock.id));
            myfile.read((char*)&innerCaffBlock.length, sizeof(innerCaffBlock.length));
            if (innerCaffBlock.id == '\x02')
            {
                // TODO: Sometihng wrong with data conversion
                CaffCredits caffCredits;
                myfile.read((char*)&caffCredits.year, 2);
                myfile.read((char*)&caffCredits.month, 1);
                myfile.read((char*)&caffCredits.day, 1);
                myfile.read((char*)&caffCredits.hour, 1);
                myfile.read((char*)&caffCredits.minute, 1);
                myfile.read((char*)&caffCredits.creator_len, 8);
                myfile.read((char*)&caffCredits.creator[0], caffCredits.creator_len);

            }
            if (innerCaffBlock.id == '\x03')
            {
                CaffAnimation ciffAnimation;
                myfile.read((char*)&ciffAnimation.duration, 8);
                myfile.read((char*)&ciffAnimation.ciff.ciffHeader.magic, 4);
                myfile.read((char*)&ciffAnimation.ciff.ciffHeader.header_size, 8);
                myfile.read((char*)&ciffAnimation.ciff.ciffHeader.content_size, 8);
                myfile.read((char*)&ciffAnimation.ciff.ciffHeader.width, 8);
                myfile.read((char*)&ciffAnimation.ciff.ciffHeader.height, 8);

                // Read caption
                char currentCaptionCharacter = '0';
                int captionSize = 0;
                while (currentCaptionCharacter != '\n')
                {
                    myfile.read((char*)&currentCaptionCharacter, 1);
                    ciffAnimation.ciff.ciffHeader.caption += currentCaptionCharacter;
                    captionSize++;
                }

                // Read tags
                char currentTagCharacter = '0';
                int index = 0;
                while (index < ciffAnimation.ciff.ciffHeader.header_size - captionSize - 36)
                {
                    myfile.read((char*)&currentTagCharacter, 1);
                    ciffAnimation.ciff.ciffHeader.tags += currentTagCharacter;
                    index++;
                }

                // Read pixels
                uint8_t currentPixel = 0;

                for (int i = 0; i < ciffAnimation.ciff.ciffHeader.content_size; i++)
                {
                    myfile.read((char*)&currentPixel, sizeof(uint8_t));
                    ciffAnimation.ciff.ciffContent.pixels.push_back(currentPixel);
                }

                // Generate image
                generateBMP(ciffAnimation.ciff.ciffContent.pixels,
                    ciffAnimation.ciff.ciffHeader.width,
                    ciffAnimation.ciff.ciffHeader.height,
                    "output");
                break;
            }
        }
        myfile.close();
    }
    catch (const std::exception&)
    {
        cout << "An error occured";
    }
    return 0;
}
