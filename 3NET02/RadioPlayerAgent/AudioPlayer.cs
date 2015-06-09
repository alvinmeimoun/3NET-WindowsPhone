using System;
using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.BackgroundAudio;

namespace RadioPlayerAgent
{
    public class AudioPlayer : AudioPlayerAgent
    {
        /// <remarks>
        /// Les instances AudioPlayer peuvent partager un même processus.
        /// Les champs statiques peuvent être utilisés pour partager un même état entre plusieurs instances AudioPlayer
        /// ou pour communiquer avec l'agent de diffusion audio en continu.
        /// </remarks>
        static AudioPlayer()
        {
            // S'abonner au gestionnaire d'exceptions prises en charge
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        /// Code à exécuter sur les exceptions non gérées
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // Une exception non gérée s'est produite ; arrêt dans le débogueur
                Debugger.Break();
            }
        }

        /// <summary>
        /// Appelé lorsque l'état de lecture change, sauf pour l'état Erreur (voir OnError)
        /// </summary>
        /// <param name="player">Le lecteur BackgroundAudioPlayer</param>
        /// <param name="track">La piste lue au moment du changement d'état de lecture</param>
        /// <param name="playState">Le nouvel état de lecture du lecteur</param>
        /// <remarks>
        /// Les changements de l'état de lecture ne peuvent pas être annulés. Ils sont appliqués même si l'application
        /// est à l'origine du changement d'état, en supposant que l'application ait accepté le rappel.
        ///
        /// Événements playstate notables :
        /// (a) TrackEnded : invoqué lorsqu'aucune piste n'est actuellement lue par le lecteur. L'agent peut alors définir la piste suivante.
        /// (b) TrackReady : une piste audio a été définie et est prête à être lue.
        ///
        /// Appelez NotifyComplete() une seule fois, après la requête de l'agent, y compris après les rappels asynchrones.
        /// </remarks>
        protected override void OnPlayStateChanged(BackgroundAudioPlayer player, AudioTrack track, PlayState playState)
        {
            switch (playState)
            {
                case PlayState.TrackEnded:
                    player.Track = GetPreviousTrack();
                    break;
                case PlayState.TrackReady:
                    player.Play();
                    break;
                case PlayState.Shutdown:
                    // TODO: gérez l'état d'arrêt (enregistrez-le, par exemple)
                    break;
                case PlayState.Unknown:
                    break;
                case PlayState.Stopped:
                    break;
                case PlayState.Paused:
                    break;
                case PlayState.Playing:
                    break;
                case PlayState.BufferingStarted:
                    break;
                case PlayState.BufferingStopped:
                    break;
                case PlayState.Rewinding:
                    break;
                case PlayState.FastForwarding:
                    break;
            }

            NotifyComplete();
        }

        /// <summary>
        /// Appelé lorsque l'utilisateur demande une action via l'interface utilisateur de l'application ou du système
        /// </summary>
        /// <param name="player">Le lecteur BackgroundAudioPlayer</param>
        /// <param name="track">La piste lue au moment de l'action de l'utilisateur</param>
        /// <param name="action">L'action demandée par l'utilisateur</param>
        /// <param name="param">Les données associées à l'action demandée.
        /// Dans la version actuelle, ce paramètre s'applique uniquement à l'action Rechercher,
        /// afin d'indiquer la position demandée pour une piste audio</param>
        /// <remarks>
        /// Les actions de l'utilisateur ne modifient pas automatiquement l'état du système ; l'agent est responsable
        /// de l'exécution des actions de l'utilisateur, si ces dernières sont prises en charge.
        ///
        /// Appelez NotifyComplete() une seule fois, après la requête de l'agent, y compris après les rappels asynchrones.
        /// </remarks>
        protected override void OnUserAction(BackgroundAudioPlayer player, AudioTrack track, UserAction action, object param)
        {
            switch (action)
            {
                case UserAction.Play:
                    if (player.PlayerState != PlayState.Playing)
                    {
                        player.Play();
                    }
                    break;
                case UserAction.Stop:
                    player.Stop();
                    break;
                case UserAction.Pause:
                    player.Pause();
                    break;
                case UserAction.FastForward:
                    player.FastForward();
                    break;
                case UserAction.Rewind:
                    player.Rewind();
                    break;
                case UserAction.Seek:
                    player.Position = (TimeSpan)param;
                    break;
                case UserAction.SkipNext:
                    player.Track = GetNextTrack();
                    break;
                case UserAction.SkipPrevious:
                    AudioTrack previousTrack = GetPreviousTrack();
                    if (previousTrack != null)
                    {
                        player.Track = previousTrack;
                    }
                    break;
            }

            NotifyComplete();
        }

        /// <summary>
        /// Implémente la logique permettant d'obtenir l'instance AudioTrack suivante.
        /// Dans une sélection, la source peut provenir d'un fichier, d'une requête Web, etc.
        /// </summary>
        /// <remarks>
        /// L'URI AudioTrack détermine la source, qui peut être :
        /// (a) un fichier de stockage isolé (URI relatif représentant un chemin d'accès dans le stockage isolé)
        /// (b) une URL HTTP (URI absolu)
        /// (c) une MediaStreamSource (Null)
        /// </remarks>
        /// <returns>une instance AudioTrack, ou Null si la lecture est terminée</returns>
        private AudioTrack GetNextTrack()
        {
            // TODO: ajoutez la logique permettant d'obtenir la piste audio suivante

            AudioTrack track = null;

            // spécifiez la piste

            return track;
        }

        /// <summary>
        /// Implémente la logique permettant d'obtenir l'instance AudioTrack précédente.
        /// </summary>
        /// <remarks>
        /// L'URI AudioTrack détermine la source, qui peut être :
        /// (a) un fichier de stockage isolé (URI relatif représentant un chemin d'accès dans le stockage isolé)
        /// (b) une URL HTTP (URI absolu)
        /// (c) une MediaStreamSource (Null)
        /// </remarks>
        /// <returns>une instance AudioTrack, ou Null si la piste précédente n'est pas autorisée</returns>
        private AudioTrack GetPreviousTrack()
        {
            // TODO: ajoutez la logique permettant d'obtenir la piste audio précédente
            AudioTrack track = null;

            // spécifiez la piste

            return track;
        }

        /// <summary>
        /// Appelé en cas d'erreur de lecture, telle qu'un problème de téléchargement d'une piste audio
        /// </summary>
        /// <param name="player">Le lecteur BackgroundAudioPlayer</param>
        /// <param name="track">La piste dans laquelle l'erreur s'est produite</param>
        /// <param name="error">L'erreur qui s'est produite</param>
        /// <param name="isFatal">Si la valeur est true, la lecture ne peut pas continuer et est interrompue</param>
        /// <remarks>
        /// Cette méthode n'est pas forcément appelée dans tous les cas. Par exemple, si l'agent d'arrière-plan
        /// comporte lui-même une exception non gérée, il ne sera pas rappelé pour gérer ses propres erreurs.
        /// </remarks>
        protected override void OnError(BackgroundAudioPlayer player, AudioTrack track, Exception error, bool isFatal)
        {
            if (isFatal)
            {
                Abort();
            }
            else
            {
                NotifyComplete();
            }

        }

        /// <summary>
        /// Appelé lorsque la demande de l'agent est annulée
        /// </summary>
        /// <remarks>
        /// Une fois la requête annulée, l'agent dispose de 5 secondes pour terminer,
        /// ce qui se traduit par l'appel de NotifyComplete()/Abort().
        /// </remarks>
        protected override void OnCancel()
        {

        }
    }
}