#include <iostream>
#include <fstream>

using namespace std;

struct CiffHeader
{
public:
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
	char* pixels;
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
		myfile.open("M:\\Iskola\\MSC\\CiffCaffParser\\CiffCaffParser\\3.caff", ios::in | ios::binary); //Change file destination
		string mode = argv[2];
		if (argc > 2 && mode.compare("CAFF") == 0)
		{
			CaffBlock cb;
			myfile.read((char*)&cb.id, 1);
			myfile.read((char*)&cb.length, 8);
			cb.data = (char*)malloc(cb.length);
			myfile.read(cb.data, cb.length);
			CaffHeader ch;
			memcpy(&ch.magic, &cb.data[0], 4);
			memcpy(&ch.header_size, &cb.data[4], 12);
			memcpy(&ch.num_anim, &cb.data[12], 8);

			free(cb.data);
			for (int i = 0; i < ch.num_anim + 1; i++)
			{
				CaffBlock cib;
				myfile.read((char*)&cib.id, sizeof(cib.id));
				myfile.read((char*)&cib.length, sizeof(cib.length));
				cib.data = (char*)malloc(cib.length);
				myfile.read(cib.data, cib.length);
				if (cib.id == '\x03')
				{
					CaffAnimation ciffAnimation;
					memcpy(&ciffAnimation.duration, &cib.data[0], 8);
					memcpy(&ciffAnimation.ciff.ciffHeader.magic[0], &cib.data[8], 4);
					memcpy(&ciffAnimation.ciff.ciffHeader.header_size, &cib.data[12], 8);
					memcpy(&ciffAnimation.ciff.ciffHeader.content_size, &cib.data[20], 8);
					memcpy(&ciffAnimation.ciff.ciffHeader.width, &cib.data[28], 8);
					memcpy(&ciffAnimation.ciff.ciffHeader.height, &cib.data[36], 8);
					ciffAnimation.ciff.ciffContent.pixels = (char*)malloc(ciffAnimation.ciff.ciffHeader.content_size);
					
					// TODO: Some memory crash
					memcpy(&ciffAnimation.ciff.ciffContent.pixels, 
						&cib.data[ciffAnimation.ciff.ciffHeader.header_size+8],
						ciffAnimation.ciff.ciffHeader.content_size);
					//generate png
					//open file
					//filewriter pixels
					//std out imageUrl
					//close file
					//generate end
					free(ciffAnimation.ciff.ciffContent.pixels);
					free(cib.data);
					break;
				}
				else {
					free(cib.data);
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
			cc.pixels = (char*)malloc(ch.content_size);
			myfile.read((char*)&cc.pixels, ch.content_size);
			//generate png
			//open file
			//filewriter pixels
			//std out imageUrl
			//close file
			//generate end
			free(cc.pixels);
		}
		myfile.close();
	}
	catch (const std::exception&)
	{
		//error kimenet
	}
	return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
