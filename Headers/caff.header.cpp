#include <string>

struct Caff
{
    byte id;
    int length;
    byte data[];
};

struct CaffHeader
{
    char magic[4];
    int header_size;
    int num_anim;
}

struct CaffCredits
{
    byte year[2];
    byte month;
    byte day;
    byte hour;
    byte minute;
    int creator_len;
    string creator;
}

struct CaffAnimation
{
    int duration;
    CiffContent ciff;
}