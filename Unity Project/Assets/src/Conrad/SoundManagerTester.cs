using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*http://www.mit.edu/~jtidwell/gof_are_guilty.html
[At the OOPSLA '99 conference, there was a "mock trial" of the Gang of Four ("GOF") -- the authors of Design Patterns, being Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides.  Their 1994 book popularized software patterns among the general software-engineering public.  Patterns had previously been used only in the domain of architecture.

At this trial, the GOF were accused of many crimes, including misleading the world on what patterns were all about, and making intermediates think they could write code like experts.  I wasn't there, but if I had been, this is what I would have said.]


The Gang of Four Are Guilty


I charge the GOF with being members of a dreadful conspiracy.

Their intentions were good, their work was excellent, and they brought patterns to the attention of the software-development public.  To that extent, I'm glad they wrote what they did.  I've become a better software engineer thanks to them, and so have many other people I know.

But let's look at their book in context with some of the other early patterns books.  For instance, consider Buschmann et. al.'s Pattern Oriented Software Architecture, and Richard Gabriel's Patterns of Software. GOF discusses micro-architectures in object-oriented software.  POSA is about, well, software architectures.  Gabriel's book is about many things, but he describes patterns as they are applied to the design and construction of software from the developer's viewpoint.

In fact, all of these books are developer-centric.

So are most of the patterns books published since.

Is this such a terrible thing?  Well, not in and of itself.  Patterns apply to this realm very nicely.  They disseminate useful knowledge, of course, and they encourage developers to take a broader view of what they're doing. (How else can I solve this problem?  How does this pattern relate to that one?  Do I use techniques and practices that might qualify as patterns?)  They permit better communication of ideas between developers, and across time.  At their best, they help turn intermediates into experts, engineers into architects, groups into teams; not only do patterns create better software, but they make life better for those who develop that software.  These, I think, are the moral dimensions that many people look for and fail to find in software patterns.

But the reality of a software artifact that the developer sees is not the only one that's important.  What about the user's reality?  Why has that been ignored in all the software patterns work that's been done?  Isn't the user's experience the ultimate reason for designing a building or a piece of software?  If that's not taken into account, how can we say our building -- or our software -- is "good"?

We claim Christopher Alexander as our inspiration.  Traditional architecture is different from software design, of course; we patterns enthusiasts are familiar with Alexander's utopian vision of people designing and building their own environment, but we know that software construction is not something lay people can do themselves in a similar fashion.

But we software builders have identified ourselves with the people who live in the buildings that Alexander talks about.  That leaves our users.... where, exactly?  As guests in our home?

If that's the case, then users are really in for it.  Already, there is way too much software out there that users can't figure out or relate to, often because engineers are doing the interface design. (For an extreme viewpoint on this topic, read Alan Cooper's TheInmates are Running the Asylum.) By continuing to treat users like outsiders in the brave new world of software patterns, we will continue to disenfranchise them.  After all, guests don't need to know what the household is really like; all they need is a nice happy veneer of fictional user-friendliness.  We can patronize them all we want, right?

Instead, maybe we should treat users like co-owners of the software. Especially when (perhaps only when) the software is something they will be using day in and day out -- it needs to be habitable for them, as well as for us.  And they will know more about their day-to-day needs than we do.  This is something that human-computer interface ("HCI") engineers have understood for years.  They have developed many practical techniques for incorporating user participation and feedback into the software design process; we just need to learn them and use them.

Back to the GOF and the conspiracy:

There's a deep chasm between software designers today.  One one side, there are the aforementioned HCI people -- those who worry about on-site observation, usability tests, storyboards, mental models, and good graphic design.  On the other side, there are the hardcore software people -- those who worry about architectures, frameworks, use cases, functionality requirements, and designing for change. (They do think about end users, but usually only as sources of use cases and requirements.)  I can count on one hand the people I know who are comfortable in both worlds.  Every software project I'm familiar with is driven by people from either one side or the other, or if they're really lucky, both at different times.

As it happened, the first software professionals to catch on to the value of patterns were hardcore software people, not HCI people.  I can't hold that against the GOF.  (I can hold it against the HCI community for missing the patterns boat, but that's a different story!)

But patterns are about, among other things, wholeness.  They are about a holistic and human-centered approach to building good things, in whatever medium you choose.  If you intend to build good software, you must consider the human experience from all sides -- the users, the builders, and whoever else interacts with the system.  None of those early patterns writers picked up on the user-centered aspect of software design.  (Gabriel at least acknowledged it, if I recall correctly, but then went explicitly in the other direction.)

Was there a conspiracy among them to ignore the user's experience?  I think there must have been.  Surely they weren't so blind as to miss it entirely, having understood patterns as well as they did!

And ever since then, most patterns enthusiasts seem to have accepted that narrow, developer-centric viewpoint as The Way It Is, because that's the way the first writers defined software patterns.  Thus the split between software designers is perpetuated for another few years.  Thus the HCI community thinks of software patterns as irrelevant to them.  Thus more software is built without involving the users as full design partners, and true software excellence remains out of reach.
*/

public class SoundManagerTester : MonoBehaviour
{
    public void Random()
    {
      SoundManager.Instance.RandomSoundEffect(SoundManager.Instance.audioClips);
    }

    public void All()
    {
      for(int i = 0; i < SoundManager.Instance.audioClips.Length; i++){
        Debug.Log("Playing Clip " + i);
        StartCoroutine(
          SoundManager.Instance.Play(
            SoundManager.Instance.audioClips[i]
          )
        );
      }
    }
}
