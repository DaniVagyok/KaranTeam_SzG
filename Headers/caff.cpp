#include "ciff.cpp"

#include <string>
using namespace std;

struct Caff
{
	char id;
	int length;
	char data[];
};

struct CaffHeader
{
	char magic[4];
	int header_size;
	int num_anim;
};

struct CaffCredits
{
	char year[2];
	char month;
	char day;
	char hour;
	char minute;
	int creator_len;
	string creator;
};

struct CaffAnimation
{
	int duration;
	CiffContent ciff;
};