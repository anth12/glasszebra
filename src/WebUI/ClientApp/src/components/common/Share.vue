<template>
    <span>
        <span>Join Code: <strong>{{ game.joinCode }}</strong></span>
        
        
        <el-button v-if="supportsShareApi" type="text" @click="share" style="float: right; padding: 3px 0">Invite players</el-button>     
        <el-popover
            v-if="!supportsShareApi"
            placement="bottom"
            trigger="hover">
            <div>
              
              <!-- https://github.com/bradvin/social-share-urls#telegramme -->
              <!-- fb-messenger://share?link={url}&app_id={app_id} -->
              <el-tooltip placement="top" content="Invite players via Email">
                <el-button
                  @click="open(`mailto:?subject=${shareTitle}&body=${shareMessage} ${shareUrl}`)">
                  <svg role="img" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><title>Gmail icon</title><path d="M24 4.5v15c0 .85-.65 1.5-1.5 1.5H21V7.387l-9 6.463-9-6.463V21H1.5C.649 21 0 20.35 0 19.5v-15c0-.425.162-.8.431-1.068C.7 3.16 1.076 3 1.5 3H2l10 7.25L22 3h.5c.425 0 .8.162 1.069.432.27.268.431.643.431 1.068z"/></svg>
                </el-button>
              </el-tooltip>
              
              <el-tooltip placement="top" content="Invite players via Facebook">
                <el-button
                  @click="open(`https://www.facebook.com/sharer.php?u=${shareUrl}`)">
                  <svg role="img" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><title>Facebook icon</title><path d="M23.9981 11.9991C23.9981 5.37216 18.626 0 11.9991 0C5.37216 0 0 5.37216 0 11.9991C0 17.9882 4.38789 22.9522 10.1242 23.8524V15.4676H7.07758V11.9991H10.1242V9.35553C10.1242 6.34826 11.9156 4.68714 14.6564 4.68714C15.9692 4.68714 17.3424 4.92149 17.3424 4.92149V7.87439H15.8294C14.3388 7.87439 13.8739 8.79933 13.8739 9.74824V11.9991H17.2018L16.6698 15.4676H13.8739V23.8524C19.6103 22.9522 23.9981 17.9882 23.9981 11.9991Z"/></svg>
                </el-button>
              </el-tooltip>
              
              <el-tooltip placement="top" content="Invite players via WhatsApp">
                <el-button
                  @click="open(`https://api.whatsapp.com/send?text=${shareTitle}%20${shareUrl}`)">
                  <svg role="img" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><title>WhatsApp icon</title><path d="M17.472 14.382c-.297-.149-1.758-.867-2.03-.967-.273-.099-.471-.148-.67.15-.197.297-.767.966-.94 1.164-.173.199-.347.223-.644.075-.297-.15-1.255-.463-2.39-1.475-.883-.788-1.48-1.761-1.653-2.059-.173-.297-.018-.458.13-.606.134-.133.298-.347.446-.52.149-.174.198-.298.298-.497.099-.198.05-.371-.025-.52-.075-.149-.669-1.612-.916-2.207-.242-.579-.487-.5-.669-.51-.173-.008-.371-.01-.57-.01-.198 0-.52.074-.792.372-.272.297-1.04 1.016-1.04 2.479 0 1.462 1.065 2.875 1.213 3.074.149.198 2.096 3.2 5.077 4.487.709.306 1.262.489 1.694.625.712.227 1.36.195 1.871.118.571-.085 1.758-.719 2.006-1.413.248-.694.248-1.289.173-1.413-.074-.124-.272-.198-.57-.347m-5.421 7.403h-.004a9.87 9.87 0 01-5.031-1.378l-.361-.214-3.741.982.998-3.648-.235-.374a9.86 9.86 0 01-1.51-5.26c.001-5.45 4.436-9.884 9.888-9.884 2.64 0 5.122 1.03 6.988 2.898a9.825 9.825 0 012.893 6.994c-.003 5.45-4.437 9.884-9.885 9.884m8.413-18.297A11.815 11.815 0 0012.05 0C5.495 0 .16 5.335.157 11.892c0 2.096.547 4.142 1.588 5.945L.057 24l6.305-1.654a11.882 11.882 0 005.683 1.448h.005c6.554 0 11.89-5.335 11.893-11.893a11.821 11.821 0 00-3.48-8.413Z"/></svg>
                </el-button>
              </el-tooltip>
              
              <el-tooltip placement="top" content="Invite players via Twitter">
                <el-button
                  @click="open(`https://twitter.com/intent/tweet?url=${shareUrl}&text=${shareMessage} ${shareUrl}&via=GlassZebra&hashtags=GlassZebra`)">
                  <svg role="img" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><title>Twitter icon</title><path d="M23.954 4.569c-.885.389-1.83.654-2.825.775 1.014-.611 1.794-1.574 2.163-2.723-.951.555-2.005.959-3.127 1.184-.896-.959-2.173-1.559-3.591-1.559-2.717 0-4.92 2.203-4.92 4.917 0 .39.045.765.127 1.124C7.691 8.094 4.066 6.13 1.64 3.161c-.427.722-.666 1.561-.666 2.475 0 1.71.87 3.213 2.188 4.096-.807-.026-1.566-.248-2.228-.616v.061c0 2.385 1.693 4.374 3.946 4.827-.413.111-.849.171-1.296.171-.314 0-.615-.03-.916-.086.631 1.953 2.445 3.377 4.604 3.417-1.68 1.319-3.809 2.105-6.102 2.105-.39 0-.779-.023-1.17-.067 2.189 1.394 4.768 2.209 7.557 2.209 9.054 0 13.999-7.496 13.999-13.986 0-.209 0-.42-.015-.63.961-.689 1.8-1.56 2.46-2.548l-.047-.02z"/></svg>
                </el-button>
              </el-tooltip>
              
              <el-tooltip placement="top" content="Invite players via Telegram">
                <el-button
                  @click="open(`https://t.me/share/url?url=${shareUrl}&text=${shareMessage} ${url}`)">
                  <svg role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><title>Telegram icon</title><path d="M23.91 3.79L20.3 20.84c-.25 1.21-.98 1.5-2 .94l-5.5-4.07-2.66 2.57c-.3.3-.55.56-1.1.56-.72 0-.6-.27-.84-.95L6.3 13.7l-5.45-1.7c-1.18-.35-1.19-1.16.26-1.75l21.26-8.2c.97-.43 1.9.24 1.53 1.73z"/></svg>
                </el-button>
              </el-tooltip>
              
              <el-tooltip placement="top" content="Invite players via SMS">
                <el-button
                  @click="open(`sms:?body=${shareUrl} ${shareTitle}`)">
                  <svg role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><title>Google Messages icon</title><path d="M.92 3.332c-.776 0-1.216.67-.692 1.383l2.537 4.403v7.86c0 2.013 1.467 3.69 3.459 3.69H20.31a3.75 3.75 0 003.69-3.69V7.043a3.723 3.723 0 00-3.668-3.71zm5.786 3.71H20.1c.587 0 1.153.357 1.153.923 0 .566-.566.922-1.153.922H6.706c-.587 0-1.153-.356-1.153-.922 0-.566.566-.923 1.153-.923zm0 3.69H20.1c.587 0 1.153.356 1.153.922 0 .566-.566.922-1.153.922H6.706c-.587 0-1.153-.356-1.153-.922 0-.566.566-.922 1.153-.922zm-.021 3.71h9.705c.587 0 1.153.356 1.153.922 0 .566-.566.923-1.153.923H6.685c-.587 0-1.153-.357-1.153-.923 0-.566.566-.922 1.153-.922Z"/></svg>
                </el-button>
              </el-tooltip>

              <br />
              
              <p>Invite players directly:</p>
              <el-tooltip placement="bottom" content="Click to copy">
                <el-button type="text"
                  @click="copyTextToClipboard(shareUrl)">
                  {{ shareUrl }}
                </el-button>
              </el-tooltip>
            </div>

            <el-button type="text" style="float: right; padding: 3px 0" slot="reference">Invite players</el-button>     
        </el-popover>
    </span>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue, Prop } from 'vue-property-decorator';
import { Message } from 'element-ui';

@Component({})
export default class Share extends Vue {
    
    supportsShareApi = (navigator as any).share != null;
  get shareTitle() { return 'Join my GlassZebra Quiz' }
  get shareMessage() { return `Join my quiz '${this.game?.name ?? ''}' on GlassZebra` }
  get shareUrl() { return location.href }

  get game() { return store.state.game; }

  open(url: string){
      console.log(`Sharing to ${url}`)
      window.open(url);
  }

  share(){
    const nav: any = navigator;
    
    if(nav.share){
      nav.share({
        title: this.shareTitle,
        text: this.shareMessage,
        url: location.href
      });
    }
  }

  copyTextToClipboard(text: string) {
    const result: boolean = (window as any).copyTextToClipboard(text);

    if(result)
      Message.success('Copied');
    else
      Message.warning(`Something went wrong. Couldn't copy to clipboard.`);
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
button svg{
    height: 20px;
    width: 20px;
}
</style>
