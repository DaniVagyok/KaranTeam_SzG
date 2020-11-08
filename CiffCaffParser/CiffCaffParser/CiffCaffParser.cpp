#include <iostream>
#include <fstream>
#include <vector>

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
	__int64 header_size;
	__int64 content_size;
	__int64 width;
	__int64 height;
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
	__int64 length;
	char* data;
};

struct CaffHeader
{
	char magic[4];
	__int64 header_size;
	__int64 num_anim;
};

struct CaffCredits
{
	char year[2];
	char month;
	char day;
	char hour;
	char minute;
	__int64 creator_len;
	string creator;
};

struct CaffAnimation
{
	__int64 duration;
	Ciff ciff;
};

int main(int argc, char* argv[])
{
	BITMAPFILEHEADER bfh;
	BITMAPINFOHEADER bih;

	// Bitmap declarations
	/* Magic number for file. It does not fit in the header structure due to alignment requirements, so put it outside */
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

	string imageUrl;
	ifstream myfile;
	try
	{
		myfile.open(argv[1], ios::in | ios::binary); //Change file destination
		string mode = argv[2];
		if (argc > 2 && mode.compare("CAFF") == 0)
		{
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
					uint8_t pixelCount = 0;
					uint8_t currentPixel = 0;

					for (int i = 0; i < ciffAnimation.ciff.ciffHeader.content_size; i++)
					{
						myfile.read((char*)&currentPixel, sizeof(uint8_t));
						ciffAnimation.ciff.ciffContent.pixels.push_back(currentPixel);
					}

					// Generate image
					int width = ciffAnimation.ciff.ciffHeader.width;
					int height = ciffAnimation.ciff.ciffHeader.height;

					bfh.bfSize = 2 + sizeof(BITMAPFILEHEADER) + sizeof(BITMAPINFOHEADER) + width * height * 3;
					bih.biWidth = width;
					bih.biHeight = height;

					FILE* file;
					fopen_s(&file, "output.bmp", "wb");
					if (!file)
					{
						printf("Could not write file\n");
						return 0;
					}

					/*Write headers*/
					fwrite(&bfType, 1, sizeof(bfType), file);
					fwrite(&bfh, 1, sizeof(bfh), file);
					fwrite(&bih, 1, sizeof(bih), file);

					/*Write bitmap*/
					for (int i = (height * width * 3)-1; i>=0; i = i - 3) {
						int x = i % width;
						int y = i / width;

						unsigned int r = ciffAnimation.ciff.ciffContent.pixels[i];
						unsigned int g = ciffAnimation.ciff.ciffContent.pixels[i-1];
						unsigned int b = ciffAnimation.ciff.ciffContent.pixels[i-2];
						fwrite(&r, 1, 1, file);
						fwrite(&g, 1, 1, file);
						fwrite(&b, 1, 1, file);
					}
					fclose(file);
					break;
				}
			}
		}
		else {  // CIFF reader - Do we need this?
			CiffHeader ch;
			CiffContent cc;
			myfile.read((char*)&ch.magic[0], sizeof(ch.magic));
			myfile.read((char*)&ch.header_size, sizeof(ch.header_size));
			myfile.read((char*)&ch.content_size, sizeof(ch.content_size));
			myfile.read((char*)&ch.width, sizeof(ch.width));
			myfile.read((char*)&ch.height, sizeof(ch.height));
			myfile.read((char*)&ch.caption, ch.header_size - 36); //a tagek is ebben vannak �gy
			myfile.read((char*)&cc.pixels, ch.content_size);
			//generate png
			//open file
			//filewriter pixels
			//std out imageUrl
			//close file
			//generate end
		}
		myfile.close();
	}
	catch (const std::exception&)
	{
		//error kimenet
	}
	return 0;
}
