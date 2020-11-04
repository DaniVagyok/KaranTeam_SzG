#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

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
	string imageUrl;
	ifstream myfile;
	try
	{
		myfile.open("M:\\Iskola\\MSC\\CiffCaffParser\\CiffCaffParser\\1.caff", ios::in | ios::binary); //Change file destination
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
					break;
					//generate png
					//open file
					//filewriter pixels
					//std out imageUrl
					//close file
					//generate end
				}
			}
		}
		else {  // CIFF reader
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

int readCaption(CiffHeader& header, ifstream file) {
	char currentCharacter = '0';
	int captionSize = 0;
	while (currentCharacter != '\n')
	{
		file.read((char*)&currentCharacter, 1);
		header.caption += currentCharacter;
		captionSize++;
	}
	return captionSize;
}